using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FileUploader.Controllers;
using FileUploader.Entity;
using FileUploader.Infrastructure.Types;

namespace FileUploader.Infrastructure
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<UserFile> UserFiles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}