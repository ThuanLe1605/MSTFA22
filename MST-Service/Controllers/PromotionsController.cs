using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Implementations;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/promotions")]
    [ApiController]
    public class PromotionsController: ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionsController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionViewModel>>> GetPromotions([FromQuery] string? search)
        {
            var result = await _promotionService.GetPromotions(search);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PromotionViewModel>>> GetPromotion([FromRoute] Guid id)
        {
            var result = await _promotionService.GetPromotion(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PromotionViewModel>> CreatePromotion([FromBody] PromotionCreateModel pro)
        {
            try
            {
                var result = await _promotionService.CreatePromotion(pro);
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
        public async Task<ActionResult<PromotionViewModel>> UpdatePromotion([FromRoute] Guid id, [FromBody] PromotionUpdateModel pro)
        {
            try
            {
                var result = await _promotionService.UpdatePromotion(id, pro);
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
