using api_pi_pi_2.DTOs;
using api_pi_pi_2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_pi_pi_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{login}, {password}")]
        public ActionResult<User?> Get(string login, string password)
        {
            User? user = Program.context.Users.ToList().Where(user => user.Login == login && user.Password == password).FirstOrDefault();
            return user == null ? NotFound("Пользователь не найден.") : Ok(user);
        }

        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] UserDTO userDto)
        {
            var existingUser = Program.context.Users.FirstOrDefault(u => u.Login == userDto.Login);
            if (existingUser != null) { return Conflict("Пользователь с таким логином уже существует."); }

            var newUser = new User
            {
                Surname = userDto.Surname,
                Name = userDto.Name,
                Patronymic = userDto.Patronymic,
                Login = userDto.Login,
                Password = userDto.Password,
                Role = userDto.Role
            };

            Program.context.Users.Add(newUser);
            Program.context.SaveChanges();
            return StatusCode(201, newUser);
        }

        [HttpPut("{idUser}")]
        public ActionResult<User> UpdatingUser(int idUser, [FromBody] UserDTO userDto)
        {
            var existingUser = Program.context.Users.FirstOrDefault(u => u.UserId == idUser);
            if (existingUser != null)
            {
                if (existingUser.Login != userDto.Login)
                {
                    var isLoginUnique = Program.context.Users.Any(u => u.Login == userDto.Login);
                    if (isLoginUnique) { return Conflict("Пользователь с таким логином уже существует."); }
                }

                existingUser.Surname = userDto.Surname;
                existingUser.Name = userDto.Name;
                existingUser.Patronymic = userDto.Patronymic;
                existingUser.Login = userDto.Login;
                existingUser.Password = userDto.Password;

                Program.context.SaveChanges();

                return NoContent();
            }
            else { return NotFound(); }
        }
    }
}
