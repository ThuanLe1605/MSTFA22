using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Implementations;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;
using System.Net.NetworkInformation;

namespace MST_Service.Controllers
{
    [Route("api/bookingStatuses")]
    [ApiController]
    public class BookingStatusController : ControllerBase
    {
        private readonly IBookingStatusService _bkStatusService;

        public BookingStatusController(IBookingStatusService bkStatusService)
        {
            _bkStatusService = bkStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingStatusViewModel>>> GetBookingStatuses(string? search)
        {
            var result = await _bkStatusService.GetBookingStatuses(search);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BookingStatusViewModel>>> GetBookingStatus([FromRoute] Guid id)
        {
            var result = await _bkStatusService.GetBookingStatus(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<BookingStatusViewModel>> CreateBookingStatus([FromBody] BookingStatusCreateModel bkStatus)
        {
            try
            {
                var result = await _bkStatusService.CreateBookingStatus(bkStatus);
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
        public async Task<ActionResult<BookingStatusViewModel>> UpdateBookingStatus([FromRoute] Guid id, [FromBody] BookingStatusUpdateModel bkStatus)
        {
            try
            {
                var result = await _bkStatusService.UpdateBookingStatus(id, bkStatus);
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
