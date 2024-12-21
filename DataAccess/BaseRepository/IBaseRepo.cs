using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BaseRepository
{
    public interface IBaseRepo<T>
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T>GetByIdAsync(string id);
        void Edit(T entity);
    }
}
