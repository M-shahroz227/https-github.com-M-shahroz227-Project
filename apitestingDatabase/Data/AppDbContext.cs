using apitestingDatabase.Model;
using Microsoft.EntityFrameworkCore;


namespace apitestingDatabase.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> UserDetail { get; set; }
        public DbSet<UsereducationDetails> UserEducationDetails { get; set; }
        public DbSet<Userwork> UserWork { get; set; }
        
    }
}
