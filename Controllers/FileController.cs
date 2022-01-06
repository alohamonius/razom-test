using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using FileUploader.Entity;
using FileUploader.Infrastructure.Repository;
using FileUploader.Infrastructure.Types;

namespace FileUploader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class FileController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;

        public FileController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => new ObjectResult(await _fileRepository.GetAllAsync());

        [HttpGet("{fileId:guid}")]
        public async Task<IActionResult> GetContent(Guid fileId)
        {
            var document = await _fileRepository.GetDetailedAsync(fileId);

            return document == null ? new NotFoundResult() : new ObjectResult(Map(document.Content));
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var permittedExtensions = new List<string> { ".txt", ".pdf" };

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {
                throw new NotSupportedException("Not supported type");
            }

            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var userFile = await _fileRepository.CreateAsync(new UploadFile(file.FileName, memoryStream.ToArray()));
            return Ok(userFile);
        }


        [HttpPut]
        [Consumes("text/plain")]
        public async Task<IActionResult> Update([FromQuery] Guid fileId, [FromBody] string base64)
        {
            var bytes = Convert.FromBase64String(base64);
            await _fileRepository.Update(fileId, bytes);
            return Ok();
        }


        [HttpDelete("{fileId:guid}")]
        public async Task<IActionResult> Delete(Guid fileId)
        {
            await _fileRepository.Remove(fileId);
            return Ok();
        }

        private static FileContent Map(byte[] content) =>
            new(System.Text.Encoding.UTF8.GetString(content));
    }
}