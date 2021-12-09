using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazomSoftware.Controllers;
using RazomSoftware.Entity;
using RazomSoftware.Infrastructure.Types;

namespace RazomSoftware.Infrastructure
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<UserFile> UserFiles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}