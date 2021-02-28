namespace Downloader
{
    class FileMetadata
    {
        public string Name { get; }
        public string Filename { get; }
        public string Url { get; }

        public FileMetadata() { }

        public FileMetadata(string name, string url, string filename)
        {
            Name = name;
            Url = url;
            Filename = filename;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
