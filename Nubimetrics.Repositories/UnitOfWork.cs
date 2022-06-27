using Nubimetrics.Repositories.Implementations;
using Nubimetrics.Repositories.Interfaces;

namespace Nubimetrics.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NubimetricsContext _context;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(NubimetricsContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }
        
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
