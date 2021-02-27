namespace Downloader
{
    class FileMetadata
    {
        private string Filename { get; set; }
        private string Url { get; set; }

        public FileMetadata() { }

        public FileMetadata(string filename, string url)
        {
            Filename = filename;
            Url = url;
        }
    }
}
