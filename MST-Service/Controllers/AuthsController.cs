using Microsoft.AspNetCore.Mvc;
using MST_Service.RequestModels.Internal;
using MST_Service.Servvices.Interfaces;
using MST_Service.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MST_Service.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthsController: ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserViewModel>> AuthenticatedUser([FromBody][Required] AuthRequest auth)
        {
            var user = await _authService.AuthenticatedUser(auth);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
