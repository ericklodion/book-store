using bs_domain.Entities;
using bs_service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_service.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDTO FromEntity(Author author)
        {
            return new AuthorDTO
            {
                Code = author.Code,
                Name = author.Name,
            };
        }

        public static Author FromDTO(AuthorDTO author)
        {
            return new Author
            {
                Code = author.Code ?? 0,
                Name = author.Name,
            };
        }
    }
}
