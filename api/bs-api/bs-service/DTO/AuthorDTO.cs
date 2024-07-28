using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_service.DTO
{
    public class AuthorDTO
    {
        public long? Code { get; set; } = null;
        public string Name { get; set; }
    }
}
