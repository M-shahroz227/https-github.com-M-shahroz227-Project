
using apitestingDatabase.Model;

namespace apitestingDatabase.Services.UserService
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task<User> CreateUserData(User user);
        public Task<User> UpdateUser(int id, User user);
        public Task<bool> DeleteUser(int id);
    }
}
