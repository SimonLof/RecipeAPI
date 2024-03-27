using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly RecipeAPIContext _context;
        public UserRepo(RecipeAPIContext context)
        {
            _context = context;
        }

        public async Task CreateUser(ApplicationUser user)
        {
            await Task.Run(() =>
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            });
        }

        public async Task DeleteUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationUser>> GetUsers()
        {
            var userList = new List<ApplicationUser>();
            await Task.Run(() =>
            {
                userList = _context.Users.ToList();
            });
            return userList;
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            await Task.Run(() =>
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            });
        }
    }
}
