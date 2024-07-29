﻿using bs_data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_data.Repositories
{
    public class BookReporitory : BaseRepository<Book>
    {
        public BookReporitory(AppDbContext context) : base(context) { }

        public async Task<Book> GetById(long code)
        {
            return await GetBaseQuery()
                .AsNoTracking()
                .Where(x=> x.Code == code)
                .FirstOrDefaultAsync();
        }

        public async Task<Book> GetByIdWithRelations(long code)
        {
            return await GetBaseQuery()
                .Include(x=> x.BookAuthors)
                    .ThenInclude(x=> x.Author)
                .Include(x => x.BookPriceTables)
                    .ThenInclude(x => x.PriceTable)
                .Include(x => x.BookSubjects)
                    .ThenInclude(x => x.Subject)
                .Where(x => x.Code == code)
                .FirstOrDefaultAsync();
        }
    }
}
