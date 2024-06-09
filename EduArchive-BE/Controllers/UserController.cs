using EduArchive_BE.Model;
using EduArchive_BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduArchive_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
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
        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            try
            {
                return Ok(
                    new ResponseMessage { Status = true, Message = "Lay tat ca user thanh cong", Data = _userRepository.GetUserById(id) }
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
                    return Ok(new ResponseMessage { Status = true, Message = "Them user thanh cong", Data = user });

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
