using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_data.Entities
{
    public class BookAuthor
    {
        public long BookCode { get; set; }
        public long AuthorCode { get; set; }


        [ForeignKey("BookCode")]
        public Book Book { get; set; }

        [ForeignKey("AuthorCode")]
        public Author Author { get; set; }
    }
}
