using bs_data;
using bs_data.Entities;
using bs_data.Repositories;
using bs_service.DTO;
using bs_service.Mappers;
using bs_shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace bs_service
{
    public class BookService
    {
        private readonly BookReporitory _repository;
        private readonly AuthorReporitory _authorRepository;
        private readonly BookViewRepository _bookViewRepository;
        private readonly UnitOfWork _unitOfWork;
        public BookService(BookReporitory repository, BookViewRepository bookViewRepository, AuthorReporitory authorRepository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _bookViewRepository = bookViewRepository;
            _unitOfWork = unitOfWork;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            var books = await _repository.GetAll();
            return books.Select(x => BookMapper.FromEntity(x)).OrderBy(x => x.Title);
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
            _unitOfWork.StartTransaction();

            var book = await _repository.GetByIdWithRelations(dto.Code.Value);
            if (book is null)
                throw new NotFoundException($"Livro com código {dto.Code.Value} não encontrado.");

            var bookDto = BookMapper.FromDTO(dto);

            var missingAuthors = book.BookAuthors.Where(x => !dto.Authors.Any(y => y == x.AuthorCode));
            var missingSubjects = book.BookSubjects.Where(x => !dto.Subjects.Any(y => y == x.SubjectCode));

            var newAuthors = dto.Authors.Where(x => !book.BookAuthors.Any(y => y.AuthorCode == x));
            var newSubjects= dto.Subjects.Where(x => !book.BookSubjects.Any(y => y.SubjectCode == x));

            foreach (var newAuthor in newAuthors)
                book.BookAuthors.Add(new BookAuthor { AuthorCode = newAuthor, BookCode = book.Code });
            foreach (var newSubject in newSubjects)
                book.BookSubjects.Add(new BookSubject { SubjectCode = newSubject, BookCode = book.Code });

            await _repository.BookAuthorDeleteRange(missingAuthors);
            await _repository.BookSubjectDeleteRange(missingSubjects);
            await _repository.BookPriceTableDeleteRange(book.BookPriceTables);

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

            book.Title = bookDto.Title;
            book.Year = bookDto.Year;
            book.Edition = bookDto.Edition;
            book.Publisher = bookDto.Publisher;

            await _repository.Update(book);

            _unitOfWork.CommitTransaction();

            return BookMapper.FromEntity(book);
        }

        public async Task Delete(long code)
        {
            var book = await _repository.GetById(code);
            if (book is null)
                throw new NotFoundException($"Livro com código {code} não encontrado.");

            await _repository.Delete(book);
        }

        public async Task<BookDTO> GetById(long code)
        {
            var book = await _repository.GetByIdWithRelations(code);
            if (book is null)
                throw new NotFoundException($"Livro com código {code} não encontrado.");

            return BookMapper.FromEntity(book);
        }

        public async Task<IEnumerable<IEnumerable<BookViewDTO>>> GetReport()
        {
            var bookView = await _bookViewRepository.GetAll();
            return bookView.Select(x => BookViewMapper.FromEntity(x)).GroupBy(x=> x.AuthorCode);
        }
    }
}
