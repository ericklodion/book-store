using bs_data.Entities;
using bs_data.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_data.Repositories
{
    public class BookViewRepository
    {
        public readonly AppDbContext _context;

        public BookViewRepository(AppDbContext context)
        {
            if (context is null)
                throw new NullReferenceException("Context is null");

            _context = context;
        }

        public async Task<IEnumerable<BookView>> GetAll()
        {
            return await _context.Set<BookView>().ToListAsync();
        }
    }
}
