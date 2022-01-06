using System;

namespace FileUploader.Infrastructure.Types
{
    public sealed record FileContent
    {
        public FileContent(string content) => Content = content;

        public string Content { get; init; }
    }
}