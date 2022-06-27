using Nubimetrics.Common.Models;

namespace Nubimetrics.Repositories.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        User UpdateUser(User user);
    }
}
