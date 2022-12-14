using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("getAllSchedule")]
        public async Task<ActionResult<IEnumerable<ScheduleViewModel>>> GetAllSchedules()
        {
            var result = await _scheduleService.GetAllSchedules();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleViewModel>> GetSchedule([FromRoute] Guid id)
        {
            var result = await _scheduleService.GetSchedule(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleViewModel>> CreateSchedule([FromBody] ScheduleCreateModel schedule)
        {
            try
            {
                var result = await _scheduleService.CreateSchedule(schedule);
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
        public async Task<ActionResult<ScheduleViewModel>> UpdateSchedule([FromRoute] Guid id, [FromBody] ScheduleUpdateModel schedule)
        {
            try
            {
                var result = await _scheduleService.UpdateSchedule(id, schedule);
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
