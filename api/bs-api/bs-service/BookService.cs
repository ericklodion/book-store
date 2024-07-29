using bs_domain;
using bs_domain.Entities;
using bs_domain.Repositories;
using bs_service.DTO;
using bs_service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_service
{
    public class BookService
    {
        private readonly BookReporitory _repository;
        private readonly UnitOfWork _unitOfWork;
        public BookService(BookReporitory repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            var books = await _repository.GetAll();
            return books.Select(x => BookMapper.FromEntity(x));
        }

        public async Task<BookDTO> Create(BookDTO dto)
        {
            _unitOfWork.StartTransaction();

            var book = BookMapper.FromDTO(dto);
            book = await _repository.Create(book);

            foreach (var subjectDTO in dto.Subjects)
            {
                var subject = new BookSubject
                {
                    BookCode = book.Code,
                    SubjectCode = subjectDTO
                };
                book.BookSubjects.Add(subject);
            }

            foreach (var authorDTO in dto.Authors)
            {
                var author = new BookAuthor
                {
                    BookCode = book.Code,
                    AuthorCode = authorDTO
                };
                book.BookAuthors.Add(author);
            }

            foreach (var priceTableDTO in dto.PriceTables)
            {
                var priceTable = new BookPriceTable
                {
                    BookCode = book.Code,
                    PriceTableCode = priceTableDTO.Code,
                    Price = priceTableDTO.Price
                };
                book.BookPriceTables.Add(priceTable);
            }

            await _repository.Update(book);

            _unitOfWork.CommitTransaction();

            return BookMapper.FromEntity(book);
        }

        public async Task<BookDTO> Update(BookDTO dto)
        {
            var book = BookMapper.FromDTO(dto);
            book = await _repository.Update(book);

            return BookMapper.FromEntity(book);
        }

        public async Task Delete(long code)
        {
            var book = await _repository.GetById(code);
            await _repository.Delete(book);
        }
    }
}
