using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RazomSoftware.Entity;
using RazomSoftware.Infrastructure.Types;

namespace RazomSoftware.Infrastructure.Repository
{
    public interface IFileRepository : IDisposable
    {
        Task<IEnumerable<UserFileViewModel>> GetAllAsync();
        Task<UserFile> GetDetailedAsync(Guid fileName);
        Task<UserFileViewModel> CreateAsync(UploadFile file);
        Task Update(Guid id, byte[] newValue);
        Task Remove(Guid id);
    }
}