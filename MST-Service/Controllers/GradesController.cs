using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Implementations;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/grades")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeViewModel>>> GetGrades([FromQuery] string? search)
        {
            var result = await _gradeService.GetGrades(search);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GradeViewModel>> GetGrade([FromRoute] Guid id)
        {
            var result = await _gradeService.GetGrade(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<GradeViewModel>> CreateGrade([FromBody] GradeCreateModel grade)
        {
            try
            {
                var result = await _gradeService.CreateGrade(grade);
                if (result != null)
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
        public async Task<ActionResult<GradeViewModel>> UpdateGrade([FromRoute] Guid id, [FromBody] GradeUpdateModel grade)
        {
            try
            {
                var result = await _gradeService.UpdateGrade(id, grade);
                if (result != null)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveGrade([FromRoute] Guid id)
        {
            try
            {
                var result = await _gradeService.RemoveGrade(id);
                if (result)
                {
                    return NoContent();
                }
                return BadRequest();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }

    }
}
