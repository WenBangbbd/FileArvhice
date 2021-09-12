using Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileArchive.AccessControl.EFCore
{
    public class AuthorityRepository : EFBaseRepository<AccessContext, Authority>, IAuthorityRepository
    {
        public AuthorityRepository(AccessContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Authority>> FindAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Authority> FindAsync(string code)
        {
            return await DbSet.SingleOrDefaultAsync(d => d.Code == code);
        }
    }
}
