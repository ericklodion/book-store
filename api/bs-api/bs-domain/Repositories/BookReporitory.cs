using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_domain.Repositories
{
    public class BookReporitory : BaseRepository
    {
        public BookReporitory(AppDbContext context) : base(context) { }
    }
}
