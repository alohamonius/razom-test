using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileUploader.Entity;
using FileUploader.Infrastructure.Types;

namespace FileUploader.Infrastructure.Repository
{
    public interface IFileRepository
    {
        Task<IEnumerable<UserFileViewModel>> GetAllAsync();
        Task<UserFile> GetDetailedAsync(Guid fileName);
        Task<UserFileViewModel> CreateAsync(UploadFile file);
        Task Update(Guid id, byte[] newValue);
        Task Remove(Guid id);
    }
}