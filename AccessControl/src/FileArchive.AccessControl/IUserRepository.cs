using FileArchive.AccessControl.Abstract;
using Infrastructure.EFCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileArchive.AccessControl
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User> FindAsync(string accountNo);
        Task<IEnumerable<User>> FindAllAsync();
    }
    public interface IAuthorityRepository : IRepository<Authority>
    {
        Task<Authority> FindAsync(string accountNo);
        Task<IEnumerable<Authority>> FindAllAsync();
    }
}