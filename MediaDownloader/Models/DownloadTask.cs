namespace MediaDownloader.Models
{
    public class DownloadTask
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Url { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;

        public string OutputPath { get; set; } = string.Empty;

        public VideoFormat? Format { get; set; }

        public DownloadStatus Status { get; set; } = DownloadStatus.Pending;

        public double Progress { get; set; }

        public double DownloadSpeed { get; set; }

        public long DownloadedBytes { get; set; }

        public long TotalBytes { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;
    }

    public enum DownloadStatus
    {
        Pending,
        Analyzing,
        Downloading,
        Processing,
        Completed,
        Failed,
        Cancelled
    }
}