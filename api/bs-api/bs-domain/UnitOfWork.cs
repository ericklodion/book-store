using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_data
{
    public class UnitOfWork : IDisposable
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void StartTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction() 
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction() 
        {
            _context.Database.RollbackTransaction();
        }

        public void Dispose()
        {
            if(_context.Database.CurrentTransaction is not null)
                _context.Database.RollbackTransaction();
        }
    }
}
