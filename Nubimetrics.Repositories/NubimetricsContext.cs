using Microsoft.EntityFrameworkCore;
using Nubimetrics.Common.Models;

namespace Nubimetrics.Repositories
{
    public class NubimetricsContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public NubimetricsContext(DbContextOptions<NubimetricsContext> options) : base(options) { }
    }
}
