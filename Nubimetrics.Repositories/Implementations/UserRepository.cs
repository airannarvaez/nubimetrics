using Microsoft.EntityFrameworkCore;
using Nubimetrics.Common.Models;
using Nubimetrics.Repositories.Interfaces;

namespace Nubimetrics.Repositories.Implementations
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(NubimetricsContext context) : base(context)
        {

        }

        public User UpdateUser(User user)
        {
            var local = _context.Set<User>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(user.Id));

            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            
            _context.Entry(user).State = EntityState.Modified;

            return user;
        }
    }
}
