using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Implementations;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressViewModel>>> GetAddresses([FromQuery] string? searchLocation)
        {
            var result = await _addressService.GetAddresses(searchLocation);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressViewModel>> GetAddress([FromRoute] Guid id)
        {
            var result = await _addressService.GetAddress(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<AddressViewModel>> CreateAddress([FromBody] AddressCreateModel address)
        {
            try
            {
                var result = await _addressService.CreateAddress(address);
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
        public async Task<ActionResult<AddressViewModel>> UpdateAddress([FromRoute] Guid id, [FromBody] AddressUpdateModel address)
        {
            try
            {
                var result = await _addressService.UpdateAddress(id, address);
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
    }
}
