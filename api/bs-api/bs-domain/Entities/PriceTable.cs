using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_data.Entities
{
    public class PriceTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Code { get; set; }

        [Required]
        [MaxLength(20)]
        public string Description { get; set; }

        public ICollection<BookPriceTable> BookPriceTables { get; set; }
    }
}
