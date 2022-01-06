using System;
using FileUploader.Entity;

namespace FileUploader.Infrastructure.Types
{
    public sealed class UserFileViewModel
    {
        public Guid Id { get; }

        public string FileName { get; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; }

        public UserFileViewModel(Guid id, string fileName, DateTime createdAt, DateTime? updatedAt)
        {
            Id = id;
            FileName = fileName;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static UserFileViewModel From(UserFile file)
        {
            return new UserFileViewModel(file.Id, file.FileName, file.CreatedAt, file.UpdatedAt);
        }
    }
}