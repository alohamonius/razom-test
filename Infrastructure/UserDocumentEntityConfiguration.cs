using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazomSoftware.Entity;
using RazomSoftware.Infrastructure.Types;

namespace RazomSoftware.Infrastructure
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