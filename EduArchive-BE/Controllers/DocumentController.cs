using EduArchive_BE.Model;
using EduArchive_BE.Services;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("search")]
        public IActionResult SearchDocuments(string? searchText, string? searchType, Guid? idSubject)
        {
         
            try
            {
                return Ok(
                    new ResponseMessage { Status = true, Message = "Lay tat ca document thanh cong", Data = _documentRepository.SearchDocument(searchText, searchType, idSubject) }
                    );
            }
            catch
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Khong The Lay User", Data = null });
            }

        
        }
        [HttpGet("ById/{id}")]
        public IActionResult GetDocumentById(Guid id)
        {
            try
            {
                var document = _documentRepository.GetDocumentById(id);
                if (document == null)
                {
                    return NotFound(new ResponseMessage { Status = false, Message = "Document not found", Data = null });
                }

                return Ok(new ResponseMessage { Status = true, Message = "Retrieve document successfully", Data = document });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Failed to retrieve document", Data = null });
            }
        }
        [HttpGet("ByIdSubject/{id}")]
        public IActionResult GetDocumentByIdSubject(Guid id)
        {
            try
            {
                var document = _documentRepository.GetDocumentByIdSubject(id);
                if (document == null)
                {
                    return NotFound(new ResponseMessage { Status = false, Message = "Document not found", Data = null });
                }

                return Ok(new ResponseMessage { Status = true, Message = "Retrieve document successfully", Data = document });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Failed to retrieve document", Data = null });
            }
        }

        [HttpGet("ByType/{type}")]
        public IActionResult GetDocumentByType(string type)
        {
            try
            {
                var documents = _documentRepository.GetDocumentByType(type);
                if (documents == null )
                {
                    return NotFound(new ResponseMessage { Status = false, Message = "No documents found for the given type", Data = null });
                }

                return Ok(new ResponseMessage { Status = true, Message = "Retrieve documents successfully", Data = documents });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseMessage { Status = false, Message = "Failed to retrieve documents", Data = null });
            }
        }
        [HttpPost()]
        [Authorize]
        public IActionResult AddDocument(Document document)
        {
            try
            {
              bool check =  _documentRepository.AddDocument(document);
              if(check==true)
                {
                    return Ok(
                 new ResponseMessage { Status = true, Message = "Them user thanh cong", Data = document }
                 );
                }
                else
                {
                    return Ok(
                 new ResponseMessage { Status = false, Message = "Khong the them user", Data = document }
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
