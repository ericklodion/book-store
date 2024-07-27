using bs_domain.Repositories;
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
    }
}
