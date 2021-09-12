using FileArchive.AccessControl.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileArchive.EFCore.Migrations
{
    public class AccessContextFactory : IDesignTimeDbContextFactory<AccessContext>
    {
        public AccessContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AccessContext>()
                .UseMySql("server=localhost;port=3306;database=filearchives;uid=root;pwd=123456", ServerVersion.Parse("5.7.18"), b => b.MigrationsAssembly("FileArchive.EFCore.Migrations"));
            return new AccessContext(builder.Options);
        }
    }
}
