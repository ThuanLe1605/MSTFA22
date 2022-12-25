using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingViewModel>>> GetBookings(string? search)
        {
            var result = await _bookingService.GetBookings(search);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BookingViewModel>>> GetBooking([FromRoute] Guid id)
        {
            var result = await _bookingService.GetBooking(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<BookingViewModel>> CreateBooking([FromBody] BookingCreateModel booking)
        {
            try
            {
                var result = await _bookingService.CreateBooking(booking);
                if (result is not null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<BookingViewModel>> UpdateBooking([FromRoute] Guid id, [FromBody] BookingUpdateModel booking)
        {
            try
            {
                var result = await _bookingService.UpdateBooking(id, booking);
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
