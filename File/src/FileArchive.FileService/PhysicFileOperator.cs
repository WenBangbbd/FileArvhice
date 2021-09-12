using FileArchive.FileService.Abstract;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.FileService
{
    public class PhysicFileOperator : IFileArchiveSaver, IFileArchiveProvider
    {
        private IOptions<FileServiceOptions> _options;
        public PhysicFileOperator(IOptions<FileServiceOptions> options)
        {
            _options = options;
        }

        public async Task<IFileInfo> GetFileInfoAsync(string subpath)
        {
            var physicalFileProvider = new PhysicalFileProvider(_options.Value.BasePath);
            return await Task.FromResult(physicalFileProvider.GetFileInfo(subpath));
        }

        public async Task SaveAsync(Stream stream, string path, string fileName)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            using FileStream fileSt = new FileStream(Path.Join(path, fileName), FileMode.CreateNew);
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, bytes.Length);
            await fileSt.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
