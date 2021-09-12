using AutoMapper;
using FileArchive.FileService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.FileService
{
    public class FileArchiveInfo : IFileArchiveInfo
    {
        public FileArchiveInfo()
        {
            CreateDateTime = DateTime.Now;
            ModifyDateTime = CreateDateTime;
        }
        public int Id { get; set; }
        public DateTime CreateDateTime {get;set;}

        public DateTime ModifyDateTime {get;set;}

        public string UUId {get;set;}

        public string Extension {get;set;}

        public string SubPath {get;set;}
    }

    
}
