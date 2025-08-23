using apitestingDatabase.Model;

namespace apitestingDatabase.Services.UsereducationDetailsService
{
    public interface IUsereducationDetailsService
    {
        Task<IEnumerable<UsereducationDetails>> GetAllUsers();
        Task<UsereducationDetails> GetUserById(int id);
        Task<UsereducationDetails> CreateUserData(UsereducationDetails user);
        Task<UsereducationDetails> UpdateUser(int id, UsereducationDetails user);
        Task DeleteUser(int id);
    }
}
