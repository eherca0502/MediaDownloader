using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using MediaDownloader.Models;

namespace MediaDownloader.Services
{
    public class HistoryService
    {
        private readonly string _historyDirectory;
        private readonly string _historyFile;


    private readonly JsonSerializerOptions _jsonOptions =
        new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public HistoryService()
        {
            _historyDirectory = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData
                ),
                "MediaDownloader"
            );

            _historyFile = Path.Combine(
                _historyDirectory,
                "history.json"
            );
        }


        public async Task<List<DownloadHistory>> GetHistoryAsync()
        {
            try
            {
                if (!File.Exists(_historyFile))
                {
                    return new List<DownloadHistory>();
                }

                string json =
                    await File.ReadAllTextAsync(
                        _historyFile
                    );

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<DownloadHistory>();
                }

                List<DownloadHistory>? history =
                    JsonSerializer.Deserialize<
                        List<DownloadHistory>
                    >(
                        json,
                        _jsonOptions
                    );

                return history
                    ?? new List<DownloadHistory>();
            }
            catch
            {
                return new List<DownloadHistory>();
            }
        }


        public async Task AddAsync(
            DownloadHistory history)
        {
            if (history == null)
            {
                throw new ArgumentNullException(
                    nameof(history)
                );
            }

            try
            {
                Directory.CreateDirectory(
                    _historyDirectory
                );

                List<DownloadHistory> historyList =
                    await GetHistoryAsync();

                historyList.Insert(
                    0,
                    history
                );

                string json =
                    JsonSerializer.Serialize(
                        historyList,
                        _jsonOptions
                    );

                await File.WriteAllTextAsync(
                    _historyFile,
                    json
                );
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "No se pudo guardar el historial.",
                    ex
                );
            }
        }


        public async Task DeleteAsync(
            DownloadHistory history)
        {
            if (history == null)
            {
                return;
            }

            try
            {
                List<DownloadHistory> historyList =
                    await GetHistoryAsync();

                historyList.Remove(history);

                string json =
                    JsonSerializer.Serialize(
                        historyList,
                        _jsonOptions
                    );

                await File.WriteAllTextAsync(
                    _historyFile,
                    json
                );
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "No se pudo eliminar el elemento del historial.",
                    ex
                );
            }
        }


        public Task ClearAsync()
        {
            try
            {
                if (File.Exists(_historyFile))
                {
                    File.Delete(
                        _historyFile
                    );
                }

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "No se pudo limpiar el historial.",
                    ex
                );
            }
        }


        public async Task<bool> HasHistoryAsync()
        {
            List<DownloadHistory> history =
                await GetHistoryAsync();

            return history.Count > 0;
        }
    }


}
