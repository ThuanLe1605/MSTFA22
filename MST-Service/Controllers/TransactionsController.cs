using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionViewModel>>> GetTransactions([FromQuery] string? search)
        {
            var result = await _transactionService.GetTransactions(search);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionViewModel>> GetTransaction([FromRoute] Guid id)
        {
            var result = await _transactionService.GetTransaction(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TransactionViewModel>> CreateTransaction([FromBody] TransactionCreateModel transaction)
        {
            try
            {
                var result = await _transactionService.CreateTransaction(transaction);
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
        public async Task<ActionResult<TransactionViewModel>> UpdateTransaction([FromRoute] Guid id, [FromBody] TransactionUpdateModel transaction)
        {
            try
            {
                var result = await _transactionService.UpdateTransaction(id, transaction);
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
