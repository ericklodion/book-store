using bs_data.Entities;
using bs_service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_service.Mappers
{
    public static class SubjectMapper
    {
        public static SubjectDTO FromEntity(Subject subject)
        {
            return new SubjectDTO
            {
                Code = subject.Code,
                Description = subject.Description,
            };
        }

        public static Subject FromDTO(SubjectDTO subject)
        {
            return new Subject
            {
                Code = subject.Code ?? 0,
                Description =subject.Description,
            };
        }
    }
}
