using apitestingDatabase.Data;
using apitestingDatabase.Model;
using Microsoft.EntityFrameworkCore;

namespace apitestingDatabase.Services.UserworkService
{
    public class UserworkService : IUserworkService
    {
        private readonly AppDbContext _context;
        public UserworkService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Userwork>> GetAllUsers()
        {
            return await _context.Set<Userwork>().ToListAsync();
        }
        public async Task<Userwork> GetUserById(int id)
        {
            return await _context.Set<Userwork>().FindAsync(id);
        }
        public async Task<Userwork> CreateUserData(Userwork user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            _context.Set<Userwork>().Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<Userwork> UpdateUser(int id, Userwork user)
        {
            if (user == null || id != user.id)
            {
                throw new ArgumentException("User data is invalid.", nameof(user));
            }
            var existingUser = await _context.Set<Userwork>().FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.id = user.id;
            existingUser.name = user.name; 
            existingUser.company = user.company; 
            existingUser.job = user.job; 
            _context.Set<Userwork>().Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }
      
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Set<Userwork>().FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Set<Userwork>().Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
