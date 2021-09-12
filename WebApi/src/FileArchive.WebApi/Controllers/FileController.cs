using FileArchive.FileService.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FileArchive.WebApi.Controllers
{
    [Route("api/[Controller]")]
    public class FileController: ControllerBase
    {
        private IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpPost()]
        public async Task<IFileArchiveInfo> AddFileAsync( IFormFile file)
        {
            HttpContext context = HttpContext;
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            var extension = file.FileName.Split('.').Last();
            return await _fileService.SaveAsync(file.OpenReadStream(), extension);
        }
        [HttpGet]
        public async Task<FileResult> GetFileAsync(string uuId)
        {
            var fileConent = await _fileService.GetFileAsync(uuId);
            FileResult file = new FileStreamResult(fileConent.FileStream, "multipart/form-data");
            file.FileDownloadName = fileConent.NameWithExtension;
            return file;
        }
    }
}
