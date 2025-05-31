namespace CookieCookbook.FileAccess
{
    public class FileMetaData
    {
        public string Name { get; }
        public FileFormat Format { get; }
        public FileMetaData(string name, FileFormat fileFormat)
        {
            Name = name;
            Format = fileFormat;
        }

        public string ToPath() => $"{Name}.{Format.AsFileExtension()}";
    }
}
