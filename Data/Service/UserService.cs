using MyApi.Data.Repository;
using MyApi.Data.Model;

namespace MyApi.Data.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepo.GetAll();
        }

        public async Task<User> GetUser(string username)
        {
            return await _userRepo.GetUser(username);
        }

        public async Task Add(User user)
        {
            await _userRepo.Add(user);
        }
    }
}