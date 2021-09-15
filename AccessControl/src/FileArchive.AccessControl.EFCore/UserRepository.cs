using FileArchive.AccessControl.Abstract;
using Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.AccessControl.EFCore
{
    public class UserRepository : EFBaseRepository<AccessContext, User>, IUserRepository
    {
        public UserRepository(AccessContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            //var list=Context.Entry<User>().Collection()
            return await DbSet.Include(d => d.RoleUsers).ThenInclude(ru=>ru.Role).ToListAsync();
        }

        public async Task<User> FindAsync(string accountNo)
        {
            return await DbSet.FirstOrDefaultAsync(u => u.AccountNo == accountNo);
        }

        public async Task<IUser> FindByNameAsync(string userName)
        {
            return await DbSet.SingleOrDefaultAsync(u => u.Name == userName);
        }
    }
}
