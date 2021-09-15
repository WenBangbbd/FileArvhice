using FileArchive.AccessControl.Activate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.Application
{
    public class FileArchiveOptions
    {
        public const string Position = "FileArchive";
        public ActivateOptions EmailActivate { get; set; }
    }
}
