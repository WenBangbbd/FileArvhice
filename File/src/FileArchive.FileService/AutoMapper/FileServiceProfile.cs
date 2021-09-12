using AutoMapper;
using FileArchive.FileService.Abstract;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.FileService.AutoMapper
{
    public class FileServiceProfile : Profile
    {
        public FileServiceProfile()
        {
            CreateMap<IFileArchiveInfo, FileConent>();
        }
    }
}
