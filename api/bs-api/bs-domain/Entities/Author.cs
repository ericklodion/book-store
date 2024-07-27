using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_domain.Entities
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Code { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
