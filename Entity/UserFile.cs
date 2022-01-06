using System;

namespace FileUploader.Entity
{
    public sealed class UserFile 
    {
        public UserFile(Guid id, string fileName, byte[] content)
        {
            Id = id;
            FileName = fileName;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }

        public string FileName { get; }

        public byte[] Content { get; private set; }

        public DateTime CreatedAt
        {
            get =>
                _dateCreated ?? DateTime.Now;
            init => _dateCreated = value;
        }

        private readonly DateTime? _dateCreated = null;

        public DateTime? UpdatedAt { get; private set; }

        public void UpdateInnerText(byte[] newValue)
        {
            Content = newValue;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}