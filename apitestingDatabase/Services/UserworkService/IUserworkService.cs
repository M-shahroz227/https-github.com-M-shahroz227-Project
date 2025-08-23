using apitestingDatabase.Model;

namespace apitestingDatabase.Services.UserworkService
{
    public interface IUserworkService
    {
        Task<IEnumerable<Userwork>> GetAllUsers();
        Task<Userwork> CreateUserData(Userwork user);
        Task<Userwork> GetUserById(int id);
        Task<Userwork> UpdateUser(int id, Userwork user);
         Task<bool> DeleteUser(int id);
        
    }
}
