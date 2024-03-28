using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.DTO;
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

        public async Task DeleteUser(int userID)
        {
            await Task.Run(() =>
            {
                var user = _context.Users.SingleOrDefault(u => u.UserID == userID);

                if (user == null) throw new Exception("User not found");

                _context.Users.Remove(user);
                _context.SaveChanges();
            });
        }

        public async Task<ApplicationUser> Login(UserLoginDTO userLogin)
        {
            return await _context.Users.SingleOrDefaultAsync(u =>
                u.UserName.ToLower() == userLogin.UserName.ToLower() && userLogin.Password == u.Password);
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
                var original = _context.Users.FirstOrDefault(u => u.UserID == user.UserID);

                if (original is null) throw new Exception("User not found.");

                _context.Entry(original).CurrentValues.SetValues(user);
                _context.SaveChanges();
            });
        }

        public async Task<ApplicationUser> GetUserById(int id)
        {
            var user = await Task.Run(() => _context.Users.FirstOrDefault(u => u.UserID == id));

            if (user is null) throw new Exception("User not found");

            return user;
        }
    }
}
