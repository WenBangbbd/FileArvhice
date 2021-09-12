using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FileArchive.FileService.EFCore
{
    public class FileContext:DbContext
    {
        public FileContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        public DbSet<FileArchiveInfo> FileArchiveInfo { get; internal set; }
    }
}