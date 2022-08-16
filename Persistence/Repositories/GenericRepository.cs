using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationC.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetByIdAsync(int id, string[] paths = null)
        {
            var model = await _dbContext.Set<T>().FindAsync(id);
            if (paths != null)
                foreach (var path in paths)
                {
                    await _dbContext.Entry((object)model).Collection(path).LoadAsync();
                }

            return model;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize, string includes = "", Expression<Func<T, bool>> expression = null)
        {
            IQueryable<T> query = (expression == null) ? _dbContext.Set<T>() : _dbContext.Set<T>().Where(expression);

            if (!string.IsNullOrEmpty(includes))
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<M>> FindAsync<M>(int pageNumber, int pageSize, string sort = null, Expression<Func<M, bool>> expression = null) where M : class
        {
            if (expression != null)
                return await _dbContext.Set<M>().Where(expression).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            else
                return await _dbContext.Set<M>().Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();

        }
    }
}
