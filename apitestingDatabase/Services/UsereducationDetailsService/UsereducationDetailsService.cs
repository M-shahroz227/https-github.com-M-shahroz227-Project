using apitestingDatabase.Data;
using apitestingDatabase.Model;
using Microsoft.EntityFrameworkCore;

namespace apitestingDatabase.Services.UsereducationDetailsService
{
    public class UsereducationDetailsService : IUsereducationDetailsService
    {
     private readonly AppDbContext _context;
        public UsereducationDetailsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UsereducationDetails>> GetAllUsers()
        {
            return await _context.Set<UsereducationDetails>().ToListAsync();
        }
        public async Task<UsereducationDetails> GetUserById(int id)
        {
            return await _context.Set<UsereducationDetails>().FindAsync(id);
        }
       public async Task<UsereducationDetails> CreateUserData(UsereducationDetails user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User data cannot be null.");
            }
            await _context.Set<UsereducationDetails>().AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<UsereducationDetails> UpdateUser(int id, UsereducationDetails user)
        {
            if (user == null || id != user.id)
            {
                throw new ArgumentException("User data is invalid.", nameof(user));
            }
            var existingUser = await _context.Set<UsereducationDetails>().FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.id = user.id;
            existingUser.name = user.name; 
            existingUser.degree = user.degree;
            existingUser.passOut = user.passOut;
            _context.Set<UsereducationDetails>().Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }
        public async Task DeleteUser(int id)
        {
            var user = await _context.Set<UsereducationDetails>().FindAsync(id);
            if (user == null)
            {
                return;
            }
            _context.Set<UsereducationDetails>().Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
