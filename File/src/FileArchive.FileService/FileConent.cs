using FileArchive.FileService.Abstract;
using System;
using System.IO;

namespace FileArchive.FileService
{
    public class FileConent : IFileConent
    {
        public Stream FileStream {get;set;}

        public DateTime CreateDateTime {get;set;}

        public DateTime ModifyDateTime {get;set;}

        public string UUId {get;set;}

        public string Extension {get;set;}

        public string SubPath {get;set;}
    }
}
