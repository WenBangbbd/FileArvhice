using FileArchive.Application;
using Microsoft.EntityFrameworkCore;

namespace FileArchive.Applicaiton.EFCore
{
    public class ApplicaitonContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivateRecord>();
        }
    }
}