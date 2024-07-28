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
        public BookService(BookReporitory repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            var books = await _repository.GetAll();
            return books.Select(x => BookMapper.FromEntity(x));
        }

        public async Task<BookDTO> Create(BookDTO dto)
        {
            var book = BookMapper.FromDTO(dto);
            book = await _repository.Create(book);

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
