using System;

namespace MediaDownloader.Models
{
    public class DownloadHistory
    {
        public string Title { get; set; } = string.Empty;


    public string Url { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Quality { get; set; } = string.Empty;

        public string Format { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string Status { get; set; } = string.Empty;
    }


}
