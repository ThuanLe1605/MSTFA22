using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentViewModel>>> GetDocuments([FromQuery] string? search)
        {
            var result = await _documentService.GetDocuments(search);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<DocumentViewModel>>> GetDocument([FromRoute] Guid id)
        {
            var result = await _documentService.GetDocument(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<DocumentViewModel>> CreateDocument([FromBody] DocumentCreateModel document)
        {
            try
            {
                var result = await _documentService.CreateDocument(document);
                if (result is not null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<DocumentViewModel>> UpdateDocument([FromRoute] Guid id, [FromBody] DocumentUpdateModel document)
        {
            try
            {
                var result = await _documentService.UpdateDocument(id, document);
                if (result is not null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
