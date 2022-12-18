using Microsoft.AspNetCore.Mvc;
using MST_Service.Entities;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/feedbacks")]
    [ApiController]
    public class FeedbacksController: ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        
        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackViewModel>>> GetFeedbacks([FromQuery] string? search)
        {
            var result = await _feedbackService.GetFeedbacks(search);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FeedbackViewModel>>> GetFeedback([FromRoute] Guid id)
        {
            var result = await _feedbackService.GetFeedback(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<FeedbackViewModel>> CreateFeedback([FromBody] FeedbackCreateModel feedback)
        {
            try
            {
                var result = await _feedbackService.CreateFeedback(feedback);
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
        public async Task<ActionResult<FeedbackViewModel>> UpdateFeedback([FromRoute] Guid id, [FromBody] FeedbackUpdateModel feedback)
        {
            try
            {
                var result = await _feedbackService.UpdateFeedback(id, feedback);
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
