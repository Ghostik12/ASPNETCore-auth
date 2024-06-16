using AuthenticationService.Models;
using AuthenticationService.Repository.IRepository;

namespace AuthenticationService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public UserRepository() 
        {
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.ru",
                Password = "Test",
                Login = "Test",
                Role = new Role()
                {
                    Id = 1,
                    Name = "Пользователь",
                }
            });
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test1",
                LastName = "Test1",
                Email = "Test1@test.ru",
                Password = "Test1",
                Login = "Login",
                Role = new Role()
                {
                    Id = 2,
                    Name = "Администратор",
                }
            });
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test3",
                LastName = "Test3",
                Email = "Test3@test.ru",
                Password = "Test3",
                Login = "Test3",
                Role = new Role()
                {
                    Id = 1,
                    Name = "Пользователь",
                }
            });
        }
        
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User? GetByLogin(string login)
        {
            var user = _users.FirstOrDefault(x => x.Login == login);
            return _users.FirstOrDefault(x => x.Login == login);
        }
    }
}
