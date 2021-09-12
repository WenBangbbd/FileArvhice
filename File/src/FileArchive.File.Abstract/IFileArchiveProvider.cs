using Microsoft.Extensions.FileProviders;
using System;
using System.Threading.Tasks;

namespace FileArchive.FileService.Abstract
{
    public interface IFileArchiveProvider
    {
        public Task<IFileInfo> GetFileInfoAsync(string subpath);
    }
}
