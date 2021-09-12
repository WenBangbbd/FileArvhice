using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Diagnostics.CodeAnalysis;

namespace FileArchive.AccessControl.EFCore
{
    public class AccessContext : DbContext
    {
        
        public AccessContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RoleUser>()
                .HasKey(r => new {r.RoleId,r.UserId });
            modelBuilder.Entity<RoleUser>()
                .HasOne(u => u.Role)
                .WithMany(r=>r.RoleUsers)
                .HasForeignKey(r=>r.RoleId);
            modelBuilder.Entity<RoleUser>()
                .HasOne(r => r.User)
                .WithMany(r => r.RoleUsers)
                .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<RoleAuthority>()
                .HasKey(r => new { r.RoleId, r.AuthorityId });
            modelBuilder.Entity<RoleAuthority>()
                .HasOne(r => r.Authority)
                .WithMany(r => r.RoleAuthorities)
                .HasForeignKey(r => r.AuthorityId);
            modelBuilder.Entity<RoleAuthority>()
                .HasOne(r => r.Role)
                .WithMany(r => r.RoleAuthorities)
                .HasForeignKey(r => r.RoleId);
        }

    }
}
