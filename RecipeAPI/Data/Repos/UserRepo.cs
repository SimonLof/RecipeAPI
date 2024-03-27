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

        public void CreateUser(ApplicationUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
