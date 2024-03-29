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

        public Task CreateUser(ApplicationUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteUser(int userID)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserID == userID);

            if (user == null) throw new Exception("User not found");

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<ApplicationUser> Login(UserLoginDTO userLogin)
        {
            return Task.FromResult<ApplicationUser>(
                _context.Users.SingleOrDefault(u =>
                u.UserName.ToLower() == userLogin.UserName.ToLower() &&
                u.Password == userLogin.Password));
        }

        public Task<List<ApplicationUser>> GetUsers()
        {
            var userList = _context.Users.ToList();

            return Task.FromResult(userList);
        }

        public Task UpdateUser(ApplicationUser user)
        {
            var original = _context.Users.FirstOrDefault(u => u.UserID == user.UserID);

            if (original is null) throw new Exception("User not found.");

            _context.Entry(original).CurrentValues.SetValues(user);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<ApplicationUser> GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserID == id);

            if (user is null) throw new Exception("User not found");

            return Task.FromResult(user);
        }
    }
}
