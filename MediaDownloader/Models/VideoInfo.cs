namespace MediaDownloader.Models
{
    public class VideoInfo
    {
        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Channel { get; set; } = string.Empty;

        public TimeSpan Duration { get; set; }

        public string ThumbnailUrl { get; set; } = string.Empty;

        public string WebpageUrl { get; set; } = string.Empty;

        public List<VideoFormat> Formats { get; set; } = new();
    }
}