using Microsoft.EntityFrameworkCore;
using MyApi.Data.Model;

namespace MyApi.Data.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly AppContext _context;
        public UserRepo(AppContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUser(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Username == username);
        }

    }
}