using bs_domain.Entities;
using bs_service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_service.Mappers
{
    public static class BookMapper
    {
        public static BookDTO FromEntity(Book book)
        {
            return new BookDTO
            {
                Code = book.Code,
                Title = book.Title,
                Publisher = book.Publisher,
                Year = book.Year
            };
        }

        public static Book FromDTO(BookDTO book)
        {
            return new Book
            {
                Code = book.Code ?? 0,
                Title = book.Title,
                Publisher = book.Publisher,
                Year = book.Year
            };
        }
    }
}
