using bs_data.Entities;
using bs_data.Views;
using bs_service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_service.Mappers
{
    public class BookViewMapper
    {
        public static BookViewDTO FromEntity(BookView book)
        {
            return new BookViewDTO
            {
                Code = book.Code,
                Title = book.Title,
                Publisher = book.Publisher,
                Year = book.Year,
                Edition = book.Edition,
                AuthorCode = book.AuthorCode,
                AuthorName = book.AuthorName,
                Price = book.Price,
                PriceTableCode = book.PriceTableCode,
                PriceTableDescription = book.PriceTableDescription,
                SubjectCode = book.SubjectCode,
                SubjectDescription = book.SubjectDescription
            };
        }
    }
}
