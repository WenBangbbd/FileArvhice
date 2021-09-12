using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.FileService.Abstract
{
    public interface IFileArchiveSaver
    {
        Task SaveAsync(Stream stream, string path, string fileName);
    }
}
