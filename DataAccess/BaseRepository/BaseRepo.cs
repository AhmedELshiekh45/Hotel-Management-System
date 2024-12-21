using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BaseRepository
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly MyContext _context;

        public BaseRepo(MyContext context)
        {
            this._context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
