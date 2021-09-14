using FileArchive.AccessControl.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FileArchive.EFCore.Migrations
{
    public class AccessContextFactory : IDesignTimeDbContextFactory<AccessContext>
    {
        public AccessContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AccessContext>()
                .UseSqlServer("Data Source=localhost;Initial Catalog=fileArchive;Persist Security Info=True;User ID=sa;Password=123456;MultipleActiveResultSets=True", builder => builder.MigrationsAssembly(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name));
            //.UseMySql("server=localhost;port=3306;database=filearchives;uid=root;pwd=123456", ServerVersion.Parse("5.7.18"), b => b.MigrationsAssembly("FileArchive.EFCore.Migrations"));
            return new AccessContext(builder.Options);
        }
    }
}
