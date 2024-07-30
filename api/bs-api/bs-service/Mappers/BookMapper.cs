using bs_data.Entities;
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
                Year = book.Year,
                Edition = book.Edition,
                Authors = book.BookAuthors.Select(x=> x.AuthorCode),
                Subjects = book.BookSubjects.Select(x=> x.SubjectCode),
                PriceTables = book.BookPriceTables.Select(x=> new BookPriceTableDTO
                {
                    Code= x.PriceTableCode,
                    Price = x.Price
                }),
            };
        }

        public static Book FromDTO(BookDTO book)
        {
            return new Book
            {
                Code = book.Code ?? 0,
                Title = book.Title,
                Publisher = book.Publisher,
                Year = book.Year,
                Edition = book.Edition,
            };
        }
    }
}
