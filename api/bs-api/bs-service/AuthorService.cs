using bs_domain.Entities;
using bs_domain.Repositories;
using bs_service.DTO;
using bs_service.Mappers;
using bs_shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace bs_service
{
    public class AuthorService
    {
        private readonly AuthorReporitory _repository;
        public AuthorService(AuthorReporitory repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AuthorDTO>> GetAll()
        {
            var authors = await _repository.GetAll();
            return authors.Select(x => AuthorMapper.FromEntity(x));
        }

        public async Task<AuthorDTO> Create(AuthorDTO dto)
        {
            var author = AuthorMapper.FromDTO(dto);
            author = await _repository.Create(author);

            return AuthorMapper.FromEntity(author);
        }

        public async Task<AuthorDTO> Update(AuthorDTO dto)
        {
            var notExists = (await _repository.GetById(dto.Code.Value) is null);
            if (notExists)
                throw new NotFoundException($"Autor com código {dto.Code.Value} não encontrado.");

            var author = AuthorMapper.FromDTO(dto);
            author = await _repository.Update(author);

            return AuthorMapper.FromEntity(author);
        }

        public async Task Delete(long code)
        {
            var author = await _repository.GetById(code);
            if (author is null)
                throw new NotFoundException($"Autor com código {code} não encontrado.");

            await _repository.Delete(author);
        }
    }
}
