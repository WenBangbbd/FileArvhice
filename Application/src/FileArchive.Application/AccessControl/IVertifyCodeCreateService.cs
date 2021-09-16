using System.Threading.Tasks;

namespace FileArchive.Application
{
    public interface IVertifyCodeCreateService
    {
        Task<string> CreateAsync();
    }
}
