using FileArchive.FileService.Abstract;
using System.Threading.Tasks;

namespace FileArchive.FileService
{
    public interface IFileArchiveRepository
    {
        Task<IFileArchiveInfo> FindAsync(string uuId);
        Task AddAsync(FileArchiveInfo info);
    }
}
