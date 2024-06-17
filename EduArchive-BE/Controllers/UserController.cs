using EduArchive_BE.Model;
using EduArchive_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduArchive_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSetting _appSettings;
        public UserController(IUserRepository userRepository, IOptionsMonitor<AppSetting> appSettingsMonitor)
        {
            _userRepository = userRepository;
            _appSettings = appSettingsMonitor.CurrentValue;
        }
        [HttpGet]
   /*     [Authorize]*/
        public IActionResult GetAllUser()
        {
            try
            {
                return Ok(
                    new ResponseMessage { Status = true, Message = "Lay tat ca user thanh cong", Data = _userRepository.GetAllUser() }
                    );
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Lay User", Data = null }) ;
            }


        }
        [HttpGet("{userName}")]
        public IActionResult GetUserByUserName(string userName)
        {
            try
            {
                return Ok(
                    new ResponseMessage { Status = true, Message = "Lay tat ca user thanh cong", Data = _userRepository.GetUserByUserName(userName) }
                    );
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Lay User", Data = null });
            }


        }
        [HttpGet("{id}/{IdGoogle}")]
        [Authorize]
        public IActionResult GetUserById(Guid id, string IdGoogle)
        {
            try
            {
                return Ok(
                    new ResponseMessage { Status = true, Message = "Lay tat ca user thanh cong", Data = _userRepository.GetUserById(id, IdGoogle) }
                    );
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Lay User", Data = null });
            }


        }
        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
              User user= _userRepository.Login(email, password);
                if (user != null)
                {
                    return Ok(new ResponseMessage { Status = true, Message = "Them user thanh cong",
                        Data = new
                        {
                            user = user, // Không cần khai báo kiểu ở đây
                            token = GenerateToken(user) // Không cần khai báo kiểu ở đây
                        }
                    }); 

                }
                else
                {

                    return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Dang Nhap", Data = null });

                }

            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Them User", Data = null });
            }

        }
        [HttpGet("logingoogle")]
        public async Task<IActionResult> LoginGoogle(string idGoogle, string email, string userName, string Avatar)
        {
            try
            {
                User user = _userRepository.LoginGoogle(idGoogle, email, userName, Avatar);
                if (user != null)
                {
                    return Ok(new ResponseMessage
                    {
                        Status = true,
                        Message = "Login Google Thành công",
                        Data = new
                        {
                            user = user, 
                            token = GenerateToken(user) // Không cần khai báo kiểu ở đây
                        }
                    });

                }
                else
                {

                    return BadRequest(new ResponseMessage { Status = false, Message = "Khoog the Login Google", Data = null });

                }

            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Them User", Data = null });
            }

        }
        private string GenerateToken(User nguoidung)
        {
            var jwrTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, nguoidung.UserName),
                    new Claim(ClaimTypes.Email, nguoidung.Email),
                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwrTokenHandler.CreateToken(tokenDescriptor);

            return jwrTokenHandler.WriteToken(token);

        }
        [HttpPost()]
        public IActionResult AddUser(User user)
        {
            try
            {
                _userRepository.AddUser(user);
                return Ok(
                    new ResponseMessage { Status = true, Message = "Them user thanh cong", Data = user }
                    );
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Them User", Data = null });
            }


        }

    }
}
