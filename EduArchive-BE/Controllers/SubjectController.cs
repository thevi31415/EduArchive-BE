using EduArchive_BE.Model;
using EduArchive_BE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduArchive_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        [HttpGet]
        public IActionResult GetAllSubject()
        {
            try
            {
                return Ok(
                    new ResponseMessage { Status = true, Message = "Lay tat ca subject thanh cong", Data = _subjectRepository.getAllSubject() }
                    );
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Lay Subject", Data = null });
            }


        }
        [HttpGet("GetRandomSubject")]
        public IActionResult GetRandomSubject()
        {
            try
            {
                return Ok(
                    new ResponseMessage { Status = true, Message = "Lay tat ca subject thanh cong", Data = _subjectRepository.GetRandomSubjects() }
                    );
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Lay Subject", Data = null });
            }


        }
        [HttpPost()]
        [Authorize]
        public IActionResult AddSubject(Subject subject)
        {
            try
            {
                _subjectRepository.AddSubject(subject);
                return Ok(
                    new ResponseMessage { Status = true, Message = "Them subject thanh cong", Data = subject }
                    );
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Them Subject", Data = null });
            }


        }
        [HttpGet("ById/{id}")]
        public IActionResult GetSubjectId(Guid id)
        {
            try
            {
                var document = _subjectRepository.GetSubjectById(id);
                if (document == null)
                {
                    return NotFound(new ResponseMessage { Status = false, Message = "Subject not found", Data = null });
                }

                return Ok(new ResponseMessage { Status = true, Message = "Retrieve subject successfully", Data = document });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Failed to retrieve document", Data = null });
            }
        }
    }
}
