using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/lectures")]
    [ApiController]
    public class LecturesController : ControllerBase
    {
        private readonly ILectureService _lectureService;

        public LecturesController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LectureViewModel>>> GetLectures([FromQuery] string? search)
        {
            var result = await _lectureService.GetLectures(search);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LectureViewModel>> GetLecture([FromRoute] Guid id)
        {
            var result = await _lectureService.GetLecture(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<LectureViewModel>> CreateLecture([FromBody] LectureCreateModel lecture)
        {
            try
            {
                var result = await _lectureService.CreateLecture(lecture);
                if (result is not null)
                {
                    return Ok(result);
                }
                return NotFound();
            } catch(Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LectureViewModel>> UpdateLecture([FromRoute]Guid id, [FromBody] LectureUpdateModel lecture)
        {
            try
            {
                var result = await _lectureService.UpdateLecture(id, lecture);
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
