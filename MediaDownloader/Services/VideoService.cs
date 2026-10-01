using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediaDownloader.Models;

namespace MediaDownloader.Services
{
    public class VideoService
    {
        private readonly ProcessService _processService;

        private readonly string _ytDlpPath;
        private readonly string _ffmpegPath;
        private readonly string _toolsPath;

        public VideoService(ProcessService processService)
        {
            _processService = processService;

            _toolsPath = Path.Combine(
                AppContext.BaseDirectory,
                "Tools"
            );

            _ytDlpPath = Path.Combine(
                _toolsPath,
                "yt-dlp.exe"
            );

            _ffmpegPath = Path.Combine(
                _toolsPath,
                "ffmpeg.exe"
            );
        }

        public async Task<VideoInfo?> GetVideoInfoAsync(
            string url,
            CancellationToken cancellationToken = default)
        {
            ValidateUrl(url);
            EnsureToolExists(_ytDlpPath, "yt-dlp.exe");

            List<string> arguments = new List<string>
            {
                "--dump-single-json",
                "--no-warnings",
                "--skip-download",
                "--ignore-config",
                "--no-plugin-dirs",
                "--",
                url.Trim()
            };

            ProcessResult result =
                await _processService.ExecuteAsync(
                    _ytDlpPath,
                    arguments,
                    cancellationToken
                );

            if (!result.Success)
            {
                throw new Exception(
                    GetProcessError(
                        result.Error,
                        "No fue posible analizar el video."
                    )
                );
            }

            if (string.IsNullOrWhiteSpace(result.Output))
            {
                throw new Exception(
                    "yt-dlp no devolvió información del video."
                );
            }

            return ParseVideoInfo(result.Output);
        }

        public async Task<string?> DownloadThumbnailAsync(
            string url,
            CancellationToken cancellationToken = default)
        {
            ValidateUrl(url);
            EnsureToolExists(_ytDlpPath, "yt-dlp.exe");

            string thumbnailDirectory = Path.Combine(
                Path.GetTempPath(),
                "MediaDownloader",
                Guid.NewGuid().ToString("N")
            );

            Directory.CreateDirectory(thumbnailDirectory);

            string filePrefix = Path.Combine(
                thumbnailDirectory,
                "thumbnail"
            );

            List<string> arguments = new List<string>
            {
                "--write-thumbnail",
                "--convert-thumbnails", "jpg",
                "--skip-download",
                "--no-warnings",
                "--ignore-config",
                "--no-plugin-dirs",
                "-o", $"{filePrefix}.%(ext)s",
                "--",
                url.Trim()
            };

            ProcessResult result =
                await _processService.ExecuteAsync(
                    _ytDlpPath,
                    arguments,
                    cancellationToken
                );

            cancellationToken.ThrowIfCancellationRequested();

            if (!result.Success)
            {
                TryDeleteDirectory(thumbnailDirectory);

                throw new Exception(
                    GetProcessError(
                        result.Error,
                        "No fue posible descargar la miniatura."
                    )
                );
            }

            string? imageFile =
                Directory
                    .GetFiles(thumbnailDirectory, "thumbnail*.jpg")
                    .OrderByDescending(File.GetLastWriteTime)
                    .FirstOrDefault();

            imageFile ??=
                Directory
                    .GetFiles(thumbnailDirectory, "thumbnail*.jpeg")
                    .OrderByDescending(File.GetLastWriteTime)
                    .FirstOrDefault();

            imageFile ??=
                Directory
                    .GetFiles(thumbnailDirectory, "thumbnail*.png")
                    .OrderByDescending(File.GetLastWriteTime)
                    .FirstOrDefault();

            imageFile ??=
                Directory
                    .GetFiles(thumbnailDirectory, "thumbnail*.webp")
                    .OrderByDescending(File.GetLastWriteTime)
                    .FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(imageFile))
            {
                return imageFile;
            }

            string[] files = Directory.GetFiles(thumbnailDirectory);

            if (files.Length > 0)
            {
                return files
                    .OrderByDescending(File.GetLastWriteTime)
                    .First();
            }

            TryDeleteDirectory(thumbnailDirectory);

            throw new Exception(
                "yt-dlp terminó correctamente, pero no se encontró el archivo de miniatura."
            );
        }

        public async Task<string> DownloadAsync(
            string url,
            string savePath,
            string downloadType,
            string quality,
            string format,
            Action<double>? progressCallback = null,
            Action<string>? statusCallback = null,
            CancellationToken cancellationToken = default)
        {
            ValidateUrl(url);
            EnsureToolExists(_ytDlpPath, "yt-dlp.exe");
            EnsureToolExists(_ffmpegPath, "ffmpeg.exe");

            if (string.IsNullOrWhiteSpace(savePath))
            {
                throw new ArgumentException(
                    "La carpeta de destino no puede estar vacía.",
                    nameof(savePath)
                );
            }

            if (string.IsNullOrWhiteSpace(downloadType))
            {
                throw new ArgumentException(
                    "El tipo de descarga no puede estar vacío.",
                    nameof(downloadType)
                );
            }

            string fullSavePath = Path.GetFullPath(savePath.Trim());
            Directory.CreateDirectory(fullSavePath);

            string extension =
                format.Trim().ToLowerInvariant();

            string type =
                downloadType.Trim().ToLowerInvariant();

            string qualityValue =
                quality.Trim().ToLowerInvariant();

            string height = ExtractHeight(qualityValue);

            List<string> arguments = new List<string>
            {
                "--newline",
                "--no-warnings",
                "--progress",
                "--ignore-config",
                "--no-plugin-dirs",
                "--windows-filenames",
                "--ffmpeg-location", _toolsPath
            };

            if (type == "audio")
            {
                arguments.Add("--extract-audio");

                switch (extension)
                {
                    case "m4a":
                        arguments.Add("--audio-format");
                        arguments.Add("m4a");
                        arguments.Add("--audio-quality");
                        arguments.Add("0");
                        break;

                    case "wav":
                        arguments.Add("--audio-format");
                        arguments.Add("wav");
                        break;

                    case "mp3":
                    default:
                        arguments.Add("--audio-format");
                        arguments.Add("mp3");
                        arguments.Add("--audio-quality");
                        arguments.Add("0");
                        break;
                }
            }
            else if (type == "video")
            {
                string videoFormat = string.IsNullOrWhiteSpace(height)
                    ? "bestvideo[ext=mp4][vcodec^=avc1]/bestvideo[ext=mp4]/bestvideo"
                    : $"bestvideo[height<={height}][ext=mp4][vcodec^=avc1]/bestvideo[height<={height}][ext=mp4]/bestvideo[height<={height}]";

                arguments.Add("-f");
                arguments.Add(videoFormat);

                switch (extension)
                {
                    case "mkv":
                        arguments.Add("--merge-output-format");
                        arguments.Add("mkv");
                        break;

                    case "webm":
                        arguments.Add("--merge-output-format");
                        arguments.Add("webm");
                        break;

                    case "mp4":
                    default:
                        arguments.Add("--remux-video");
                        arguments.Add("mp4");
                        break;
                }
            }
            else if (type == "video + audio" ||
                     type == "videoaudio")
            {
                string videoFormat = string.IsNullOrWhiteSpace(height)
                    ? "bestvideo+bestaudio/best"
                    : $"bestvideo[height<={height}]+bestaudio/best[height<={height}]";

                arguments.Add("-f");
                arguments.Add(videoFormat);

                switch (extension)
                {
                    case "mkv":
                        arguments.Add("--merge-output-format");
                        arguments.Add("mkv");
                        break;

                    case "webm":
                        arguments.Add("--merge-output-format");
                        arguments.Add("webm");
                        break;

                    case "mp4":
                    default:
                        arguments.Add("--merge-output-format");
                        arguments.Add("mp4");
                        arguments.Add("--ppa");
                        arguments.Add("Merger+ffmpeg_o:-c:a aac -b:a 192k");
                        break;
                }
            }
            else
            {
                throw new ArgumentException(
                    "Tipo de descarga no válido.",
                    nameof(downloadType)
                );
            }

            string outputTemplate = Path.Combine(
                fullSavePath,
                "%(title)s.%(ext)s"
            );

            arguments.Add("-o");
            arguments.Add(outputTemplate);

            arguments.Add("--print");
            arguments.Add("after_move:__MEDIADOWNLOADER_FILE__%(filepath)s");

            arguments.Add("--");
            arguments.Add(url.Trim());

            statusCallback?.Invoke("Iniciando descarga...");

            ProcessResult result =
                await _processService.ExecuteWithProgressAsync(
                    _ytDlpPath,
                    arguments,
                    line => ParseDownloadProgress(
                        line,
                        progressCallback,
                        statusCallback
                    ),
                    cancellationToken
                );

            cancellationToken.ThrowIfCancellationRequested();

            if (!result.Success)
            {
                throw new Exception(
                    GetProcessError(
                        result.Error,
                        "La descarga no pudo completarse."
                    )
                );
            }

            string downloadedFile = ExtractDownloadedFilePath(result.Output);

            if (string.IsNullOrWhiteSpace(downloadedFile))
            {
                throw new Exception(
                    "La descarga terminó correctamente, pero no fue posible determinar el archivo generado."
                );
            }

            downloadedFile = Path.GetFullPath(downloadedFile);

            if (!File.Exists(downloadedFile))
            {
                throw new Exception(
                    "yt-dlp indicó que la descarga terminó, pero el archivo no se encontró en la ubicación esperada."
                );
            }

            string normalizedSavePath =
                Path.GetFullPath(fullSavePath)
                    .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                + Path.DirectorySeparatorChar;

            if (!downloadedFile.StartsWith(
                normalizedSavePath,
                StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                    "La descarga generó un archivo fuera de la carpeta de destino."
                );
            }

            progressCallback?.Invoke(100);
            statusCallback?.Invoke("Descarga completada.");

            return downloadedFile;
        }

        private static string ExtractDownloadedFilePath(string output)
        {
            const string marker = "__MEDIADOWNLOADER_FILE__";

            if (string.IsNullOrWhiteSpace(output))
            {
                return string.Empty;
            }

            string[] lines = output.Split(
                new[] { "\r\n", "\n", "\r" },
                StringSplitOptions.RemoveEmptyEntries
            );

            for (int i = lines.Length - 1; i >= 0; i--)
            {
                string line = lines[i].Trim();

                int markerIndex =
                    line.IndexOf(marker, StringComparison.Ordinal);

                if (markerIndex < 0)
                {
                    continue;
                }

                string path =
                    line[(markerIndex + marker.Length)..].Trim();

                if (!string.IsNullOrWhiteSpace(path))
                {
                    return path.Trim('\"');
                }
            }

            return string.Empty;
        }

        private static void ValidateUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException(
                    "La URL no puede estar vacía.",
                    nameof(url)
                );
            }

            string trimmedUrl = url.Trim();

            if (!Uri.TryCreate(
                trimmedUrl,
                UriKind.Absolute,
                out Uri? uri))
            {
                throw new ArgumentException(
                    "La URL no tiene un formato válido.",
                    nameof(url)
                );
            }

            if (uri.Scheme != Uri.UriSchemeHttp &&
                uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new ArgumentException(
                    "Solo se permiten URLs HTTP o HTTPS.",
                    nameof(url)
                );
            }

            if (string.IsNullOrWhiteSpace(uri.Host))
            {
                throw new ArgumentException(
                    "La URL debe incluir un dominio válido.",
                    nameof(url)
                );
            }
        }

        private static void EnsureToolExists(
            string path,
            string toolName)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(
                    $"No se encontró {toolName}.",
                    path
                );
            }
        }

        private static string GetProcessError(
            string error,
            string fallback)
        {
            if (string.IsNullOrWhiteSpace(error))
            {
                return fallback;
            }

            string cleaned = error.Trim();

            const int maxLength = 4000;

            if (cleaned.Length > maxLength)
            {
                cleaned = cleaned[..maxLength] + "...";
            }

            return cleaned;
        }

        private static void TryDeleteDirectory(string directory)
        {
            try
            {
                if (Directory.Exists(directory))
                {
                    Directory.Delete(directory, recursive: true);
                }
            }
            catch
            {
            }
        }

        private static string ExtractHeight(
            string quality)
        {
            if (string.IsNullOrWhiteSpace(
                quality))
            {
                return string.Empty;
            }

            string digits =
                new string(
                    quality
                        .TakeWhile(
                            char.IsDigit
                        )
                        .ToArray()
                );

            return digits;
        }


        private static void ParseDownloadProgress(
            string line,
            Action<double>? progressCallback,
            Action<string>? statusCallback)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            string text =
                line.Trim();


            int percentIndex =
                text.IndexOf('%');

            if (percentIndex >= 0)
            {
                string beforePercent =
                    text[..percentIndex];

                string number =
                    new string(
                        beforePercent
                            .Reverse()
                            .TakeWhile(
                                c =>
                                    char.IsDigit(c)
                                    ||
                                    c == '.'
                            )
                            .Reverse()
                            .ToArray()
                    );

                if (double.TryParse(
                    number,
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out double progress))
                {
                    progress =
                        Math.Clamp(
                            progress,
                            0,
                            100
                        );

                    progressCallback?.Invoke(
                        progress
                    );
                }
            }


            if (text.Contains(
                "[download]",
                StringComparison.OrdinalIgnoreCase))
            {
                statusCallback?.Invoke(
                    text
                        .Replace(
                            "[download]",
                            "",
                            StringComparison.OrdinalIgnoreCase
                        )
                        .Trim()
                );
            }
            else if (text.Contains(
                "Merging",
                StringComparison.OrdinalIgnoreCase))
            {
                statusCallback?.Invoke(
                    "Uniendo video y audio..."
                );
            }
            else if (text.Contains(
                "Extracting",
                StringComparison.OrdinalIgnoreCase))
            {
                statusCallback?.Invoke(
                    "Procesando archivo..."
                );
            }
        }


        private VideoInfo ParseVideoInfo(
            string json)
        {
            using JsonDocument document =
                JsonDocument.Parse(json);

            JsonElement root =
                document.RootElement;

            VideoInfo videoInfo =
                new VideoInfo
                {
                    Id =
                        GetString(
                            root,
                            "id"
                        ),

                    Title =
                        GetString(
                            root,
                            "title"
                        ),

                    Channel =
                        GetString(
                            root,
                            "channel"
                        ),

                    ThumbnailUrl =
                        GetString(
                            root,
                            "thumbnail"
                        ),

                    WebpageUrl =
                        GetString(
                            root,
                            "webpage_url"
                        ),

                    Duration =
                        TimeSpan.FromSeconds(
                            GetDouble(
                                root,
                                "duration"
                            )
                        )
                };

            if (root.TryGetProperty(
                "formats",
                out JsonElement formats))
            {
                foreach (
                    JsonElement format
                    in formats.EnumerateArray())
                {
                    VideoFormat videoFormat =
                        ParseFormat(
                            format
                        );

                    if (!string.IsNullOrWhiteSpace(
                        videoFormat.FormatId))
                    {
                        videoInfo.Formats.Add(
                            videoFormat
                        );
                    }
                }
            }

            return videoInfo;
        }

        private VideoFormat ParseFormat(
            JsonElement format)
        {
            return new VideoFormat
            {
                FormatId =
                    GetString(
                        format,
                        "format_id"
                    ),

                Extension =
                    GetString(
                        format,
                        "ext"
                    ),

                Resolution =
                    GetString(
                        format,
                        "resolution"
                    ),

                Width =
                    GetInt(
                        format,
                        "width"
                    ),

                Height =
                    GetInt(
                        format,
                        "height"
                    ),

                VideoCodec =
                    GetString(
                        format,
                        "vcodec"
                    ),

                AudioCodec =
                    GetString(
                        format,
                        "acodec"
                    ),

                FileSize =
                    GetLong(
                        format,
                        "filesize"
                    ),

                Bitrate =
                    GetDouble(
                        format,
                        "abr"
                    ),

                HasVideo =
                    HasCodec(
                        format,
                        "vcodec"
                    ),

                HasAudio =
                    HasCodec(
                        format,
                        "acodec"
                    )
            };
        }


        private static bool HasCodec(
            JsonElement element,
            string property)
        {
            string value =
                GetString(
                    element,
                    property
                );

            return
                !string.IsNullOrWhiteSpace(value)
                &&
                value != "none";
        }


        private static string GetString(
            JsonElement element,
            string property)
        {
            if (!element.TryGetProperty(
                property,
                out JsonElement value))
            {
                return string.Empty;
            }

            return value.ValueKind switch
            {
                JsonValueKind.String =>
                    value.GetString()
                    ?? string.Empty,

                JsonValueKind.Null =>
                    string.Empty,

                _ =>
                    value.ToString()
            };
        }



        private static int GetInt(
            JsonElement element,
            string property)
        {
            if (!element.TryGetProperty(
                property,
                out JsonElement value))
            {
                return 0;
            }

            if (value.ValueKind ==
                JsonValueKind.Null)
            {
                return 0;
            }

            if (value.ValueKind ==
                    JsonValueKind.Number &&
                value.TryGetInt32(
                    out int result))
            {
                return result;
            }

            if (value.ValueKind ==
                    JsonValueKind.String &&
                int.TryParse(
                    value.GetString(),
                    out int stringResult))
            {
                return stringResult;
            }

            return 0;
        }

        private static long GetLong(
            JsonElement element,
            string property)
        {
            if (!element.TryGetProperty(
                property,
                out JsonElement value))
            {
                return 0;
            }

            if (value.ValueKind ==
                JsonValueKind.Null)
            {
                return 0;
            }

            if (value.ValueKind ==
                    JsonValueKind.Number &&
                value.TryGetInt64(
                    out long result))
            {
                return result;
            }

            if (value.ValueKind ==
                    JsonValueKind.String &&
                long.TryParse(
                    value.GetString(),
                    out long stringResult))
            {
                return stringResult;
            }

            return 0;
        }


        private static double GetDouble(
            JsonElement element,
            string property)
        {
            if (!element.TryGetProperty(
                property,
                out JsonElement value))
            {
                return 0;
            }

            if (value.ValueKind ==
                JsonValueKind.Null)
            {
                return 0;
            }

            if (value.ValueKind ==
                    JsonValueKind.Number &&
                value.TryGetDouble(
                    out double result))
            {
                return result;
            }

            if (value.ValueKind ==
                    JsonValueKind.String &&
                double.TryParse(
                    value.GetString(),
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out double stringResult))
            {
                return stringResult;
            }

            return 0;
        }
    }
}