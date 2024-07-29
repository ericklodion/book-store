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
using System.Xml.Linq;

namespace bs_service
{
    public class SubjectService
    {
        private readonly SubjectReporitory _repository;
        public SubjectService(SubjectReporitory repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SubjectDTO>> GetAll()
        {
            var subjects = await _repository.GetAll();
            return subjects.Select(x => SubjectMapper.FromEntity(x)).OrderBy(x => x.Description);
        }

        public async Task<SubjectDTO> Create(SubjectDTO dto)
        {
            var subject = SubjectMapper.FromDTO(dto);
            subject = await _repository.Create(subject);

            return SubjectMapper.FromEntity(subject);
        }

        public async Task<SubjectDTO> Update(SubjectDTO dto)
        {
            var notExists = (await _repository.GetById(dto.Code.Value) is null);
            if (notExists)
                throw new NotFoundException($"Assunto com código {dto.Code.Value} não encontrado.");

            var subject = SubjectMapper.FromDTO(dto);
            subject = await _repository.Update(subject);

            return SubjectMapper.FromEntity(subject);
        }

        public async Task Delete(long code)
        {
            var subject = await _repository.GetById(code);
            if (subject is null)
                throw new NotFoundException($"Assunto com código {code} não encontrado.");

            await _repository.Delete(subject);
        }
    }
}
