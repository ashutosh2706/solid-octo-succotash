using MyApi.Data.Model;

namespace MyApi.Data.Repository
{
    public interface IUserRepo
    {
        Task Add(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUser(string username);
    }
}