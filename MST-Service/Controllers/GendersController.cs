using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Implementations;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/genders")]
    [ApiController]
    public class GendersController: ControllerBase
    {
        private readonly IGenderService _genderService;
        public GendersController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenderViewModel>>> GetGenders()
        {
            var result = await _genderService.GetGenders();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GenderViewModel>>> GetGender([FromRoute] Guid id)
        {
            var result = await _genderService.GetGender(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<GenderViewModel>> CreateGender([FromBody] GenderCreateModel name)
        {
            try
            {
                var result = await _genderService.CreateGender(name);
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
        public async Task<ActionResult<GenderViewModel>> UpdateGender([FromRoute] Guid id, [FromBody] GenderUpdateModel name)
        {
            try
            {
                var result = await _genderService.UpdateGender(id, name);
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
