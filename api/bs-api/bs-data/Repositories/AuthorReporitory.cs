
using bs_data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_data.Repositories
{
    public class AuthorReporitory : BaseRepository<Author>
    {
        public AuthorReporitory(AppDbContext context) : base(context) { }

        public async Task<Author> GetById(long code)
        {
            return await GetBaseQuery().AsNoTracking().Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}
