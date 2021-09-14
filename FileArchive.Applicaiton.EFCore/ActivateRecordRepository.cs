using FileArchive.Application;
using Infrastructure.EFCore;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FileArchive.Applicaiton.EFCore
{
    public class ActivateRecordRepository : EFBaseRepository<ApplicaitonContext, ActivateRecord>, IActivateRecordRepository
    {
        public ActivateRecordRepository(ApplicaitonContext context) : base(context)
        {
        }

        public async Task<ActivateRecord> FindByAsync(string userName, string activateCode)
        {
            return await DbSet.SingleOrDefaultAsync(r => r.UserName == userName && r.ActivateCode == activateCode);
        }
    }
}
