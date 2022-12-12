using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Implementations;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _payService;

        public PaymentsController(IPaymentService payService)
        {
            _payService = payService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentViewModel>>> GetPayments()
        {
            var result = await _payService.GetPayments();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PaymentViewModel>>> GetPayment([FromRoute] Guid id)
        {
            var result = await _payService.GetPayment(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PaymentViewModel>> CreatePayment([FromBody] PaymentCreateModel pay)
        {
            try
            {
                var result = await _payService.CreatePayment(pay);
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
        public async Task<ActionResult<PaymentViewModel>> UpdatePayment([FromRoute] Guid id, [FromBody] PaymentUpdateModel pay)
        {
            try
            {
                var result = await _payService.UpdatePayment(id, pay);
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
