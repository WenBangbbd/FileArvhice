using AutoMapper;
using FileArchive.FileService.Abstract;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileArchive.FileService
{
    public class FileService : IFileService
    {
        private readonly IFileArchiveProvider _fileProvider;
        private readonly IFileArchiveRepository _fileRep;
        private readonly IFileArchiveSaver _fileSaver;
        private readonly IMapper _mapper;
        private readonly IFileUUIdCreator _fileUUIdCreator;
        private readonly FileServiceOptions _options;

        public FileService(
            IFileArchiveProvider fileProvider, 
            IFileArchiveRepository fileRep, 
            IFileArchiveSaver fileSaver, 
            IMapper mapper, 
            IFileUUIdCreator fileUUIdCreator, 
            IOptions<FileServiceOptions> options)
        {
            _fileProvider = fileProvider;
            _fileRep = fileRep;
            _fileSaver = fileSaver;
            _mapper = mapper;
            _fileUUIdCreator = fileUUIdCreator;
            _options = options.Value;
        }

        public async Task<IFileConent> GetFileAsync(string uuId)
        {
            if (uuId is null)
            {
                throw new ArgumentNullException(nameof(uuId));
            }

            IFileArchiveInfo fileInfo = await _fileRep.FindAsync(uuId);
            var file = await _fileProvider.GetFileInfoAsync(fileInfo.UUIDWithSubPath);
            var fileContent = _mapper.Map<FileConent>(fileInfo);
            fileContent.FileStream = file.CreateReadStream();
            return fileContent;
        }

        public async Task<IFileArchiveInfo> SaveAsync(Stream stream, string extension)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            if (extension is null)
            {
                throw new ArgumentNullException(nameof(extension));
            }
            var uuId = _fileUUIdCreator.Create();
            var subPath = DateTime.Now.ToString("yyyyMMdd");
            var fullPath = Path.Join(_options.BasePath, subPath);
            await _fileSaver.SaveAsync(stream, fullPath, uuId);
            var info = new FileArchiveInfo { Extension = extension, SubPath = subPath, UUId = uuId };
            await _fileRep.AddAsync(info);
            return info;
        }
    }
}
