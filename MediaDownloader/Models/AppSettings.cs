using System;

namespace MediaDownloader.Models
{
    public class AppSettings
    {
        public string DownloadPath { get; set; } =
            Environment.GetFolderPath(
                Environment.SpecialFolder.MyVideos
            );

        public string DefaultType { get; set; } =
            "Video";

        public string DefaultQuality { get; set; } =
            "Mejor calidad";

        public string DefaultFormat { get; set; } =
            "MP4";

        public bool SaveHistory { get; set; } = true;

        public bool ConfirmCancel { get; set; } = true;

        public bool ShowNotifications { get; set; } = true;
    }
}
