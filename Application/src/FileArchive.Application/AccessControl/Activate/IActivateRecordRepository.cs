using Infrastructure.EFCore;
using System.Threading.Tasks;

namespace FileArchive.Application
{
    public interface IActivateRecordRepository : IRepository<ActivateRecord>
    {
        Task<ActivateRecord> FindByAsync(string userName, string activateCode);
    }
}
