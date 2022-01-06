using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FileUploader.Entity;
using FileUploader.Infrastructure.Types;

namespace FileUploader.Infrastructure
{
    public class UserDocumentEntityConfiguration :IEntityTypeConfiguration<UserFile>
    {
        public void Configure(EntityTypeBuilder<UserFile> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FileName).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
        }
    }
}