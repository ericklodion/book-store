using bs_domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_service.DTO
{
    public class BookDTO
    {
        public long? Code { get; set; } = null;
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Edition { get; set; }
        public int Year { get; set; }

        public IEnumerable<long> Subjects { get; set; }
        public IEnumerable<long> Authors { get; set; }
        public IEnumerable<BookPriceTableDTO> PriceTables { get; set; }
    }
}
