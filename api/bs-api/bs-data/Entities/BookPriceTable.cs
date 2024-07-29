using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_data.Entities
{
    public class BookPriceTable
    {
        public long BookCode { get; set; }
        public long PriceTableCode { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("BookCode")]
        public Book Book { get; set; }

        [ForeignKey("PriceTableCode")]
        public PriceTable PriceTable { get; set; }
    }
}
