using FileArchive.AccessControl.Abstract;
using Infrastructure.EFCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileArchive.AccessControl
{
    public interface IRoleRepository:IRepository<Role>
    {
        public Task<Role> FindAsync(string code);
        Task<IEnumerable<Role>> FindAllAsync();
    }
}
