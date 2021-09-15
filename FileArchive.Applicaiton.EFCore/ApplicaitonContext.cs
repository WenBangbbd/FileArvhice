using FileArchive.AccessControl.Activate;
using FileArchive.Application;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace FileArchive.Applicaiton.EFCore
{
    public class ApplicaitonContext:DbContext
    {
        public ApplicaitonContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivateRecord>();
        }
    }
}