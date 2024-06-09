using EduArchive_BE.Model;
using EduArchive_BE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduArchive_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        [HttpGet]
        public IActionResult GetAllDocument()
        {
            try
            {
                return Ok(
                    new ResponseMessage { Status = true, Message = "Lay tat ca document thanh cong", Data = _documentRepository.GetAllDocument() }
                    );
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Lay User", Data = null });
            }


        }
        [HttpGet("{id}")]
        public IActionResult GetDocumentById(Guid id)
        {
            try
            {
                return Ok(
                    new ResponseMessage { Status = true, Message = "Lay tat ca document thanh cong", Data = _documentRepository.GetDocumentById(id) }
                    );
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Lay User", Data = null });
            }


        }
        [HttpPost()]
        public IActionResult AddDocument(Document document)
        {
            try
            {
                _documentRepository.AddDocument(document);
                return Ok(
                    new ResponseMessage { Status = true, Message = "Them user thanh cong", Data = document }
                    );
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Them User", Data = null });
            }


        }

    }
}
