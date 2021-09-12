using FileArchive.FileService.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FileArchive.FileService.EFCore
{
    public class FileArchiveRepository : IFileArchiveRepository
    {
        private readonly FileContext _context;

        public FileArchiveRepository(FileContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FileArchiveInfo info)
        {
            await _context.FileArchiveInfo.AddAsync(info);
            await _context.SaveChangesAsync();
        }

        public async Task<IFileArchiveInfo> FindAsync(string uuId)
        {
            return await _context.FileArchiveInfo.FirstOrDefaultAsync(f => f.UUId == uuId);
        }
    }
}
