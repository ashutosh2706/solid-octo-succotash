using MyApi.Data.Model;

namespace MyApi.Data.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUser(string username);
        Task Add(User user);
    }
}