using Blog.Core.Entities;
using Blog.Data.Context;
using Blog.Data.Repositories.Abstract;
using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> Table { get => _dbContext.Set<T>(); }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task AddAsync(T entity) // Task = void
        {
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(expression);
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.SingleAsync();
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression = null)
        {
            return await Table.CountAsync(expression);
        }

        public Task<T> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
