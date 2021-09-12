using System.IO;

namespace FileArchive.FileService.Abstract
{
    public interface IFileConent:IFileArchiveInfo
    {
        /// <summary>
        /// 文件内容
        /// </summary>
        public Stream FileStream { get; }
    }
}
