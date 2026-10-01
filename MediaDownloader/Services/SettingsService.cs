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

            Directory.CreateDirectory(appDataPath);

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

                    await SaveSettingsAsync(defaultSettings);
                    return defaultSettings;
                }

                string json =
                    await File.ReadAllTextAsync(_settingsPath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    AppSettings defaultSettings =
                        CreateDefaultSettings();

                    await SaveSettingsAsync(defaultSettings);
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

                    await SaveSettingsAsync(defaultSettings);
                    return defaultSettings;
                }

                NormalizeSettings(settings);
                return settings;
            }
            catch
            {
                return CreateDefaultSettings();
            }
        }

        public async Task SaveSettingsAsync(AppSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            NormalizeSettings(settings);

            try
            {
                string json =
                    JsonSerializer.Serialize(
                        settings,
                        _jsonOptions
                    );

                string tempPath =
                    _settingsPath + ".tmp";

                await File.WriteAllTextAsync(
                    tempPath,
                    json
                );

                File.Move(
                    tempPath,
                    _settingsPath,
                    overwrite: true
                );
            }
            catch (Exception ex)
            {
                try
                {
                    string tempPath =
                        _settingsPath + ".tmp";

                    if (File.Exists(tempPath))
                    {
                        File.Delete(tempPath);
                    }
                }
                catch
                {
                }

                throw new IOException(
                    "No fue posible guardar la configuración.",
                    ex
                );
            }
        }

        public async Task<AppSettings> ResetSettingsAsync()
        {
            AppSettings defaultSettings =
                CreateDefaultSettings();

            await SaveSettingsAsync(defaultSettings);
            return defaultSettings;
        }

        public bool SettingsExists()
        {
            return File.Exists(_settingsPath);
        }

        public string GetSettingsPath()
        {
            return _settingsPath;
        }

        public AppSettings GetDefaultSettings()
        {
            return CreateDefaultSettings();
        }

        private static AppSettings CreateDefaultSettings()
        {
            return new AppSettings
            {
                DownloadPath =
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyVideos
                    ),
                DefaultType = "Video",
                DefaultQuality = "Mejor calidad",
                DefaultFormat = "MP4",
                SaveHistory = true,
                ConfirmCancel = true,
                ShowNotifications = true
            };
        }

        private static void NormalizeSettings(AppSettings settings)
        {
            if (string.IsNullOrWhiteSpace(settings.DownloadPath))
            {
                settings.DownloadPath =
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyVideos
                    );
            }

            if (string.IsNullOrWhiteSpace(settings.DefaultType))
            {
                settings.DefaultType = "Video";
            }

            if (string.IsNullOrWhiteSpace(settings.DefaultQuality))
            {
                settings.DefaultQuality = "Mejor calidad";
            }

            if (string.IsNullOrWhiteSpace(settings.DefaultFormat))
            {
                settings.DefaultFormat = "MP4";
            }
        }
    }
}
