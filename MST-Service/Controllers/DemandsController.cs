using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/demands")]
    [ApiController]
    public class DemandsController : ControllerBase
    {
        private readonly IDemandService _demandService;

        public DemandsController(IDemandService demandService)
        {
            _demandService = demandService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DemandViewModel>>> GetDemands([FromQuery] Guid? genderId, Guid? subjectId, Guid? gradeId, Guid? syllabusId)
        {
            var result = await _demandService.GetDemands(genderId, subjectId, gradeId, syllabusId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DemandViewModel>> GetDemand([FromRoute] Guid id)
        {
            var result = await _demandService.GetDemand(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<DemandViewModel>> CreateDemand([FromBody] DemandCreateModel demand)
        {
            try
            {
                var result = await _demandService.CreateDemand(demand);
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
        public async Task<ActionResult<DemandViewModel>> UpdateDemand([FromRoute] Guid id, [FromBody] DemandUpdateModel demand)
        {
            try
            {
                var result = await _demandService.UpdateDemand(id, demand);
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
