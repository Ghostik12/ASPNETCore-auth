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
                Email = "Test",
                Password = "Test",
                Login = "Test",
            });
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test1",
                LastName = "Test1",
                Email = "Test1",
                Password = "Test1",
                Login = "Login",
            });
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                Password = "Test",
                Login = "Test",
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
