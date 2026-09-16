using System;
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
            if (!File.Exists(_ytDlpPath))
            {
                throw new FileNotFoundException(
                    "No se encontró yt-dlp.exe.",
                    _ytDlpPath
                );
            }

            string arguments =
                $"--dump-single-json " +
                $"--no-warnings " +
                $"--skip-download " +
                $"\"{url}\"";

            ProcessResult result =
                await _processService.ExecuteAsync(
                    _ytDlpPath,
                    arguments,
                    cancellationToken
                );

            if (!result.Success)
            {
                throw new Exception(
                    string.IsNullOrWhiteSpace(result.Error)
                        ? "No fue posible analizar el video."
                        : result.Error
                );
            }

            if (string.IsNullOrWhiteSpace(result.Output))
            {
                throw new Exception(
                    "yt-dlp no devolvió información del video."
                );
            }

            return ParseVideoInfo(
                result.Output
            );
        }


        public async Task<string?> DownloadThumbnailAsync(
            string url,
            CancellationToken cancellationToken = default)
        {
            if (!File.Exists(_ytDlpPath))
            {
                throw new FileNotFoundException(
                    "No se encontró yt-dlp.exe.",
                    _ytDlpPath
                );
            }

            string thumbnailDirectory =
                Path.Combine(
                    Path.GetTempPath(),
                    "MediaDownloader",
                    "Thumbnails"
                );

            Directory.CreateDirectory(
                thumbnailDirectory
            );

            try
            {
                foreach (string file in
                    Directory.GetFiles(
                        thumbnailDirectory))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }

            string filePrefix =
                Path.Combine(
                    thumbnailDirectory,
                    "thumbnail"
                );

            string arguments =
                $"--write-thumbnail " +
                $"--convert-thumbnails jpg " +
                $"--skip-download " +
                $"--no-warnings " +
                $"-o \"{filePrefix}.%(ext)s\" " +
                $"\"{url}\"";

            ProcessResult result =
                await _processService.ExecuteAsync(
                    _ytDlpPath,
                    arguments,
                    cancellationToken
                );

            cancellationToken.ThrowIfCancellationRequested();

            if (!result.Success)
            {
                throw new Exception(
                    string.IsNullOrWhiteSpace(result.Error)
                        ? "No fue posible descargar la miniatura."
                        : result.Error
                );
            }

            string? imageFile =
                Directory
                    .GetFiles(
                        thumbnailDirectory,
                        "thumbnail*.jpg"
                    )
                    .OrderByDescending(
                        File.GetLastWriteTime
                    )
                    .FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(imageFile))
            {
                return imageFile;
            }

            imageFile =
                Directory
                    .GetFiles(
                        thumbnailDirectory,
                        "thumbnail*.jpeg"
                    )
                    .OrderByDescending(
                        File.GetLastWriteTime
                    )
                    .FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(imageFile))
            {
                return imageFile;
            }

            imageFile =
                Directory
                    .GetFiles(
                        thumbnailDirectory,
                        "thumbnail*.png"
                    )
                    .OrderByDescending(
                        File.GetLastWriteTime
                    )
                    .FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(imageFile))
            {
                return imageFile;
            }

            imageFile =
                Directory
                    .GetFiles(
                        thumbnailDirectory,
                        "thumbnail*.webp"
                    )
                    .OrderByDescending(
                        File.GetLastWriteTime
                    )
                    .FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(imageFile))
            {
                return imageFile;
            }

            string[] files =
                Directory.GetFiles(
                    thumbnailDirectory
                );

            if (files.Length > 0)
            {
                return files
                    .OrderByDescending(
                        File.GetLastWriteTime
                    )
                    .First();
            }

            throw new Exception(
                "yt-dlp terminó correctamente, pero no se encontró el archivo de miniatura."
            );
        }


        public async Task DownloadAsync(
            string url,
            string savePath,
            string downloadType,
            string quality,
            string format,
            Action<double>? progressCallback = null,
            Action<string>? statusCallback = null,
            CancellationToken cancellationToken = default)
        {
            if (!File.Exists(_ytDlpPath))
            {
                throw new FileNotFoundException(
                    "No se encontró yt-dlp.exe.",
                    _ytDlpPath
                );
            }

            if (!File.Exists(_ffmpegPath))
            {
                throw new FileNotFoundException(
                    "No se encontró ffmpeg.exe. Colócalo dentro de la carpeta Tools.",
                    _ffmpegPath
                );
            }

            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException(
                    "La URL no puede estar vacía.",
                    nameof(url)
                );
            }

            if (string.IsNullOrWhiteSpace(savePath))
            {
                throw new ArgumentException(
                    "La carpeta de destino no puede estar vacía.",
                    nameof(savePath)
                );
            }

            Directory.CreateDirectory(savePath);

            string extension =
                format
                    .Trim()
                    .ToLowerInvariant();

            string type =
                downloadType
                    .Trim()
                    .ToLowerInvariant();

            string qualityValue =
                quality
                    .Trim()
                    .ToLowerInvariant();

            string height = ExtractHeight(qualityValue);

            string formatArguments;

            if (type == "audio")
            {
                switch (extension)
                {
                    case "mp3":

                        formatArguments =
                            "-x " +
                            "--audio-format mp3 " +
                            "--audio-quality 0";

                        break;

                    case "m4a":

                        formatArguments =
                            "-x " +
                            "--audio-format m4a " +
                            "--audio-quality 0";

                        break;

                    case "wav":

                        formatArguments =
                            "-x " +
                            "--audio-format wav";

                        break;

                    default:

                        formatArguments =
                            "-x " +
                            "--audio-format mp3 " +
                            "--audio-quality 0";

                        break;
                }
            }

            else if (type == "video")
            {
                string videoFormat;

                if (string.IsNullOrWhiteSpace(height))
                {
                    videoFormat =
                        "bestvideo[ext=mp4][vcodec^=avc1]/bestvideo[ext=mp4]/bestvideo";
                }
                else
                {
                    videoFormat =
                        $"bestvideo[height<={height}][ext=mp4][vcodec^=avc1]/" +
                        $"bestvideo[height<={height}][ext=mp4]/" +
                        $"bestvideo[height<={height}]";
                }

                switch (extension)
                {
                    case "mp4":

                        formatArguments =
                            $"-f \"{videoFormat}\" " +
                            "--remux-video mp4";

                        break;

                    case "mkv":

                        formatArguments =
                            $"-f \"{videoFormat}\" " +
                            "--merge-output-format mkv";

                        break;

                    case "webm":

                        formatArguments =
                            $"-f \"{videoFormat}\" " +
                            "--merge-output-format webm";

                        break;

                    default:

                        formatArguments =
                            $"-f \"{videoFormat}\" " +
                            "--remux-video mp4";

                        break;
                }
            }

            else
            {
                string videoFormat;

                if (string.IsNullOrWhiteSpace(height))
                {
                    videoFormat =
                        "bestvideo+bestaudio/best";
                }
                else
                {
                    videoFormat =
                        $"bestvideo[height<={height}]+bestaudio/" +
                        $"best[height<={height}]";
                }

                switch (extension)
                {
                    case "mp4":

                        formatArguments =
                            $"-f \"{videoFormat}\" " +
                            "--merge-output-format mp4 " +
                            "--ppa \"Merger+ffmpeg_o:-c:a aac -b:a 192k\"";

                        break;

                    case "mkv":

                        formatArguments =
                            $"-f \"{videoFormat}\" " +
                            "--merge-output-format mkv";

                        break;

                    case "webm":

                        formatArguments =
                            $"-f \"{videoFormat}\" " +
                            "--merge-output-format webm";

                        break;

                    default:

                        formatArguments =
                            $"-f \"{videoFormat}\" " +
                            "--merge-output-format mp4 " +
                            "--ppa \"Merger+ffmpeg_o:-c:a aac -b:a 192k\"";

                        break;
                }
            }

            string outputTemplate =
                Path.Combine(
                    savePath,
                    "%(title)s.%(ext)s"
                );

            string arguments =
                $"--newline " +
                $"--no-warnings " +
                $"--progress " +
                $"--ffmpeg-location \"{_toolsPath}\" " +
                $"{formatArguments} " +
                $"-o \"{outputTemplate}\" " +
                $"\"{url}\"";

            statusCallback?.Invoke(
                "Iniciando descarga..."
            );

            ProcessResult result =
                await _processService.ExecuteWithProgressAsync(
                    _ytDlpPath,
                    arguments,
                    line =>
                    {
                        ParseDownloadProgress(
                            line,
                            progressCallback,
                            statusCallback
                        );
                    },
                    cancellationToken
                );

            cancellationToken.ThrowIfCancellationRequested();

            if (!result.Success)
            {
                string error =
                    string.IsNullOrWhiteSpace(result.Error)
                        ? "La descarga no pudo completarse."
                        : result.Error.Trim();

                throw new Exception(error);
            }

            progressCallback?.Invoke(100);

            statusCallback?.Invoke(
                "Descarga completada."
            );
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