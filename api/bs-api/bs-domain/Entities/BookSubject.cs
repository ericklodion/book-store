using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_domain.Entities
{
    public class BookSubject
    {
        public long BookCode { get; set; }
        public long SubjectCode { get; set; }


        [ForeignKey("BookCode")]
        public Book Book { get; set; }

        [ForeignKey("SubjectCode")]
        public Subject Subject { get; set; }
    }
}
