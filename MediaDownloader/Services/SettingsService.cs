using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediaDownloader.Models;

namespace MediaDownloader.Services
{
    public class SettingsService
    {
        private readonly string _settingsPath;


    private readonly JsonSerializerOptions _jsonOptions =
        new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition =
                JsonIgnoreCondition.Never
        };

        public SettingsService()
        {
            string appDataPath =
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.ApplicationData
                    ),
                    "MediaDownloader"
                );

            Directory.CreateDirectory(
                appDataPath
            );

            _settingsPath =
                Path.Combine(
                    appDataPath,
                    "settings.json"
                );
        }

        public async Task<AppSettings> GetSettingsAsync()
        {
            try
            {
                if (!File.Exists(_settingsPath))
                {
                    AppSettings defaultSettings =
                        CreateDefaultSettings();

                    await SaveSettingsAsync(
                        defaultSettings
                    );

                    return defaultSettings;
                }

                string json =
                    await File.ReadAllTextAsync(
                        _settingsPath
                    );

                if (string.IsNullOrWhiteSpace(json))
                {
                    AppSettings defaultSettings =
                        CreateDefaultSettings();

                    await SaveSettingsAsync(
                        defaultSettings
                    );

                    return defaultSettings;
                }

                AppSettings? settings =
                    JsonSerializer.Deserialize<AppSettings>(
                        json,
                        _jsonOptions
                    );

                if (settings == null)
                {
                    AppSettings defaultSettings =
                        CreateDefaultSettings();

                    await SaveSettingsAsync(
                        defaultSettings
                    );

                    return defaultSettings;
                }

                return settings;
            }
            catch
            {
                return CreateDefaultSettings();
            }
        }

        public async Task SaveSettingsAsync(
            AppSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(
                    nameof(settings)
                );
            }

            try
            {
                string json =
                    JsonSerializer.Serialize(
                        settings,
                        _jsonOptions
                    );

                await File.WriteAllTextAsync(
                    _settingsPath,
                    json
                );
            }
            catch (Exception ex)
            {
                throw new IOException(
                    "No fue posible guardar la configuración.",
                    ex
                );
            }
        }

        
        public async Task<AppSettings>
            ResetSettingsAsync()
        {
            AppSettings defaultSettings =
                CreateDefaultSettings();

            await SaveSettingsAsync(
                defaultSettings
            );

            return defaultSettings;
        }

        public bool SettingsExists()
        {
            return File.Exists(
                _settingsPath
            );
        }

        public string GetSettingsPath()
        {
            return _settingsPath;
        }

        
        public AppSettings GetDefaultSettings()
        {
            return CreateDefaultSettings();
        }

        private AppSettings CreateDefaultSettings()
        {
            return new AppSettings
            {
                DownloadPath =
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyVideos
                    ),

                DefaultQuality =
                    "Mejor calidad",

                DefaultFormat =
                    "MP4",

                ShowCompletionMessage =
                    true
            };
        }
    }


}

