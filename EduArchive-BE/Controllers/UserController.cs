﻿using EduArchive_BE.Model;
using EduArchive_BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
