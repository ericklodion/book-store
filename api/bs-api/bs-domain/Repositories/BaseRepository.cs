using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_domain.Repositories
{
    public class BaseRepository<T> where T : class
    {
        public readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            if (context is null)
                throw new NullReferenceException("Context is null");

            _context = context;
        }

        public IQueryable<T> GetBaseQuery() {
            return _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll() {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
