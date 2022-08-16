using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationC.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int id, string[] paths = null);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<List<T>> GetPagedReponseAsync(int pageNumber, int pageSize, string includes="", Expression<Func<T, bool>> expression = null);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
