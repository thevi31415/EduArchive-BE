using EduArchive_BE.Model;
using EduArchive_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduArchive_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowSubjectController : ControllerBase
    {
        private readonly IFollowSubjectRepository _followSubjectRepository;
        public FollowSubjectController(IFollowSubjectRepository followSubjectRepository)
        {
            _followSubjectRepository = followSubjectRepository;
        }

        [HttpPost]

        [Authorize]
        public IActionResult AddFollowSubject(FollowSubject followSubject)
        {
            try
            {
                bool check = _followSubjectRepository.AddFollowSubject(followSubject);
                if (check == true)
                {
                    return Ok(
                 new ResponseMessage { Status = true, Message = "Theo doi mon hoc thanh cong", Data = followSubject }
                 );
                }
                else
                {
                    return Ok(
                 new ResponseMessage { Status = false, Message = "Khong the theo doi mon hoc", Data = followSubject }
                 );
                }

            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Them User", Data = null });
            }


        }
        [HttpGet]

        /*   [Authorize]*/
        public IActionResult CheckFollowSubject(Guid idSubject, Guid idUser)
        {
            try
            {
                bool check = _followSubjectRepository.CheckFollowSubject(idSubject, idUser);
                if (check == true)
                {
                    return Ok(
                 new ResponseMessage { Status = true, Message = "Theo doi mon hoc thanh cong", Data = true }
                 );
                }
                else
                {
                    return Ok(
                 new ResponseMessage { Status = false, Message = "Khong the theo doi mon hoc", Data = null }
                 );
                }

            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Them User", Data = null });
            }


        }
        [HttpGet("GetFollowSubjectByUserId")]

        /*   [Authorize]*/
        public IActionResult GetFollowSubjectByUserId(Guid idUser)
        {
            try
            {
                    return Ok(
                 new ResponseMessage { Status = true, Message = "Theo doi mon hoc thanh cong", Data = _followSubjectRepository.GetFollowSubjectsByIduser(idUser) });
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Them User", Data = null });
            }


        }
        [HttpDelete]

        [Authorize]
        public IActionResult RemoveFollowSubject(Guid idSubject, Guid idUser)
        {
            try
            {
                bool check = _followSubjectRepository.RemoveFollowSubject(idSubject, idUser);
                if (check == true)
                {
                    return Ok(
                 new ResponseMessage { Status = true, Message = "Xoa theo doi thanh cong", Data = true }
                 );
                }
                else
                {
                    return Ok(
                 new ResponseMessage { Status = false, Message = "Khong the xoa theo doi", Data = null }
                 );
                }

            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Them User", Data = null });
            }


        }

    }
}
