using Nubimetrics.Repositories.Interfaces;

namespace Nubimetrics.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task<int> Complete();
    }
}
