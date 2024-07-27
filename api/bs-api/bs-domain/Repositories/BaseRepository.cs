using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_domain.Repositories
{
    public class BaseRepository
    {
        public readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
