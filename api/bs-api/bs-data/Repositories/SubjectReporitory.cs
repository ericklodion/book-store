
using bs_data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_data.Repositories
{
    public class SubjectReporitory : BaseRepository<Subject>
    {
        public SubjectReporitory(AppDbContext context) : base(context) { }

        public async Task<Subject> GetById(long code)
        {
            return await GetBaseQuery().Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}
