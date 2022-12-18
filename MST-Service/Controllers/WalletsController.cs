using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Create;
using MST_Service.RequestModels.Update;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;

namespace MST_Service.Controllers
{
    [Route("api/wallets")]
    [ApiController]
    public class WalletsController : Controller
    {
        private readonly IWalletService _walletService;

        public WalletsController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WalletViewModel>>> GetWallets([FromQuery] string? search)
        {
            var result = await _walletService.GetWallets(search);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WalletViewModel>> GetWallet([FromRoute] Guid id)
        {
            var result = await _walletService.GetWallet(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<WalletViewModel>> CreateWallet([FromBody] WalletCreateModel wallet)
        {
            try
            {
                var result = await _walletService.CreateWallet(wallet);
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
        public async Task<ActionResult<WalletViewModel>> UpdateWallet([FromRoute] Guid id, [FromBody] WalletUpdateModel wallet)
        {
            try
            {
                var result = await _walletService.UpdateWallet(id, wallet);
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
