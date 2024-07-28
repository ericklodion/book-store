using bs_domain.Entities;
using bs_domain.Repositories;
using bs_service.DTO;
using bs_service.Mappers;
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
            return subjects.Select(x => SubjectMapper.FromEntity(x));
        }

        public async Task<SubjectDTO> Create(SubjectDTO dto)
        {
            var subject = SubjectMapper.FromDTO(dto);
            subject = await _repository.Create(subject);

            return SubjectMapper.FromEntity(subject);
        }

        public async Task<SubjectDTO> Update(SubjectDTO dto)
        {
            var subject = SubjectMapper.FromDTO(dto);
            subject = await _repository.Update(subject);

            return SubjectMapper.FromEntity(subject);
        }

        public async Task Delete(long code)
        {
            var subject = await _repository.GetById(code);
            await _repository.Delete(subject);
        }
    }
}
