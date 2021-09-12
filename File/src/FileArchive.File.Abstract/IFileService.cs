using System.IO;
using System.Threading.Tasks;

namespace FileArchive.FileService.Abstract
{
    public interface IFileService
    {
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        public Task<IFileArchiveInfo> SaveAsync(Stream stream, string extension);
        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="uuId"></param>
        /// <returns></returns>
        public Task<IFileConent> GetFileAsync(string uuId);
    }
}
