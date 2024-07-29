using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_data.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Code { get; set; }

        [Required]
        [MaxLength(40)]
        public string Title { get; set; }

        [Required]
        [MaxLength(40)]
        public string Publisher { get; set; }

        [Required]
        public int Edition { get; set; }

        [Required]
        [MaxLength(4)]
        public int Year { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<BookSubject> BookSubjects { get; set; } = new List<BookSubject>();
        public ICollection<BookPriceTable> BookPriceTables { get; set; } = new List<BookPriceTable>();
    }
}
