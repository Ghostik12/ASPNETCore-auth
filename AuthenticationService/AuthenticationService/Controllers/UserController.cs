using AuthenticationService.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Authentication;
using System.Security.Claims;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private ILogger _logger;
        private IMapper _mapper;
        private UserRepository _userRepository;
        public UserController( ILogger logger, IMapper mapper) 
        {
            _logger = logger;
            _mapper = mapper;

            logger.WriteEvent("f");
            logger.WriteError("e");
        }

        [Authorize]
        [HttpGet]
        [Route("viewmodel")]
        public UserViewModel GetUserViewModel(int id)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Ivan",
                LastName = "IVanov",
                Email = "ivan@mail.ru",
                Password = "password",
                Login = "Login"
            };

            var userViewModel = _mapper.Map<UserViewModel>(user); // с помощью автомапера

            //UserViewModel userViewModel = new UserViewModel(user); // в ручную делали маппинг

            return userViewModel;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<UserViewModel> Authenticate(string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
                    throw new ArgumentNullException("Запрос не корректен");

            var user = _userRepository.GetByLogin(login);
            if (user == null)
                throw new AuthenticationException("Пользователь не найден");

            if (user.Password != password)
                throw new AuthenticationException("Введенный пароль не корректен");

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "AppCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity)); 

            return _mapper.Map<UserViewModel>(user);
        }
    }
}
