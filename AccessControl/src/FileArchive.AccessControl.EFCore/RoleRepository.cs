using Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileArchive.AccessControl.EFCore
{
    public class RoleRepository : EFBaseRepository<AccessContext, Role>, IRoleRepository
    {
        public RoleRepository(AccessContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Role>> FindAllAsync()
        {
            return await DbSet.Include(d=>d.RoleAuthorities).ThenInclude(r=>r.Authority).ToListAsync();
        }

        public async Task<Role> FindAsync(string code)
        {
            return await DbSet.SingleOrDefaultAsync(d => d.Code == code);
        }
    }
}
