
using Infrastructure.EFCore;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FileArchive.AccessControl.Activate;

namespace FileArchive.AccessControl.EFCore
{
    public class ActivateRecordRepository : EFBaseRepository<AccessContext, ActivateRecord>, IActivateRecordRepository
    {
        public ActivateRecordRepository(AccessContext context) : base(context)
        {
        }

        public async Task<ActivateRecord> FindByAsync(string userName, string activateCode)
        {
            return await DbSet.SingleOrDefaultAsync(r => r.UserName == userName && r.ActivateCode == activateCode);
        }
    }
}
