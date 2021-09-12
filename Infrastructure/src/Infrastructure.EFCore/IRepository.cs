using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.EFCore
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task InsertAsync(TEntity entity);
        Task<TEntity> FindAsync([CanBeNull] params object[] keyValues);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task InsertRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
    public abstract class EFBaseRepository<TDbContext, TEntity> : IRepository<TEntity> where TEntity : class, new() where TDbContext : DbContext
    {
        protected TDbContext Context { get; private set; }
        protected DbSet<TEntity> DbSet => Context.Set<TEntity>();
        protected EFBaseRepository(TDbContext context)
        {
            Context = context;
        }

        public async Task<TEntity> FindAsync([CanBeNull] params object[] keyValues)
        {
            return await Context.FindAsync<TEntity>(keyValues);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }
        public async Task RemoveAsync(TEntity entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }
        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            Context.UpdateRange(entities);
            await Context.SaveChangesAsync();
        }
        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            Context.RemoveRange(entities);
            await Context.SaveChangesAsync();
        }
    }
}
