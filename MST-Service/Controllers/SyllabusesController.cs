using Microsoft.AspNetCore.Mvc;
using MST_Service.Entities;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Implementations;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/syllabuses")]
    [ApiController]
    public class SyllabusesController : ControllerBase
    {
        private readonly ISyllabusService _syllabusService;
        public SyllabusesController(ISyllabusService syllabusService)
        {
            _syllabusService = syllabusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SyllabusViewModel>>> GetSylabuses([FromQuery] string? search)
        {
            var result = await _syllabusService.GetSylabuses(search);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SyllabusViewModel>>> GetSylabus([FromRoute] Guid id)
        {
            var result = await _syllabusService.GetSylabus(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<SyllabusViewModel>> CreateSylabus([FromBody] SylabusCreateModel syllabus)
        {
            try
            {
                var result = await _syllabusService.CreateSylabus(syllabus);
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
        public async Task<ActionResult<SyllabusViewModel>> UpdateSylabus([FromRoute] Guid id, [FromBody] SylabusUpdateModel syllabus)
        {
            try
            {
                var result = await _syllabusService.UpdateSylabus(id, syllabus);
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
