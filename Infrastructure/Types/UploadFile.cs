namespace FileUploader.Infrastructure.Types
{
    public sealed class UploadFile
    {
        public UploadFile(string fileName, byte[] content)
        {
            FileName = fileName;
            Content = content;
        }

        public string FileName { get; }
        public byte[] Content { get; private set; }
    }
}