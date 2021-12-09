using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazomSoftware.Entity;
using RazomSoftware.Infrastructure.Types;

namespace RazomSoftware.Infrastructure.Repository
{
    public sealed class FileRepository : IFileRepository
    {
        private readonly IApplicationDbContext _applicationContext;

        public FileRepository(IApplicationDbContext applicationContext) => _applicationContext = applicationContext;

        public async Task<IEnumerable<UserFileViewModel>> GetAllAsync() =>
            (await _applicationContext.UserFiles.ToListAsync()).Select(UserFileViewModel.From);
     
        public Task<UserFile> GetDetailedAsync(Guid id) =>
            _applicationContext.UserFiles.FirstAsync(c => c.Id.Equals(id))!;

        public async Task<UserFileViewModel> CreateAsync(UploadFile dto)
        {
            var id = Guid.NewGuid();
            var file = new UserFile(id, dto.FileName, dto.Content);
            await _applicationContext.UserFiles.AddAsync(file);
            await _applicationContext.SaveChangesAsync();
            return UserFileViewModel.From(file);
        }

        public async Task Update(Guid id, byte[] newValue)
        {
            var document = await _applicationContext.UserFiles.FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (document == null) throw new Exception($"Some db exception: {id}");
            document.UpdateInnerText(newValue);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var toDelete = await GetDetailedAsync(id);
            if (toDelete == null) throw new Exception($"Some db exception : {id}");
            _applicationContext.UserFiles.Remove(toDelete);
            await _applicationContext.SaveChangesAsync();
        }

        private bool _disposed;

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _applicationContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}