using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_service.DTO
{
    public class BookViewDTO
    {
        public long? Code { get; set; } = null;
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Edition { get; set; }
        public int Year { get; set; }
        public long? AuthorCode { get; set; }
        public string? AuthorName { get; set; }
        public long? SubjectCode { get; set; }
        public string? SubjectDescription { get; set; }
        public long? PriceTableCode { get; set; }
        public string? PriceTableDescription { get; set; }
        public decimal? Price { get; set; }
    }
}
