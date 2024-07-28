using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_service.DTO
{
    public class PriceTableDTO
    {
        public long? Code { get; set; } = null;
        public string Description { get; set; }
    }
}
