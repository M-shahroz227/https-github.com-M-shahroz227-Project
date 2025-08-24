
using apitestingDatabase.Data;
using apitestingDatabase.Model;
using Microsoft.EntityFrameworkCore;

namespace apitestingDatabase.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var data = await _context.Set<User>().ToListAsync();
            return data;
        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Set<User>().FindAsync(id);
            return user;
        }
        public async Task<User> CreateUserData(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            _context.Set<User>().Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUser(int id, User user)
        {
            if (user == null || id != user.id)
            {
                throw new ArgumentException("User data is invalid.", nameof(user));
            }
            var existingUser = await _context.Set<User>().FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.id = user.id; 
            existingUser.name = user.name; 
            existingUser.email = user.email;
            existingUser.address = user.address;
            _context.Set<User>().Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Set<User>().FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Set<User>().Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
