namespace MediaDownloader.Models
{
    public class VideoFormat
    {
        public string FormatId { get; set; } = string.Empty;

        public string Extension { get; set; } = string.Empty;

        public string Resolution { get; set; } = string.Empty;

        public int Width { get; set; }

        public int Height { get; set; }

        public string VideoCodec { get; set; } = string.Empty;

        public string AudioCodec { get; set; } = string.Empty;

        public long FileSize { get; set; }

        public bool HasVideo { get; set; }

        public bool HasAudio { get; set; }

        public double Bitrate { get; set; }

        public string DisplayName
        {
            get
            {
                if (HasVideo && HasAudio)
                    return $"{Resolution} - {Extension} - Video + Audio";

                if (HasVideo)
                    return $"{Resolution} - {Extension} - Video";

                if (HasAudio)
                    return $"{Bitrate:0} kbps - {Extension} - Audio";

                return Extension;
            }
        }
    }
}