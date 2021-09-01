using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Application.HelperModels;
using System.Threading.Tasks;

namespace SportskiCentarRS2.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthenticationController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto model)
        {
            var result = await _identityService.LoginUserAsync(model, HttpContext);
            if(result.Succeeded)
                return Ok(result.SuccessMessage);

            return BadRequest(result);
        }
        [HttpGet("logout")]
        public async Task<IActionResult> LogOut()
        {
            await _identityService.SignOutAsync();

            return Ok();
        }
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody]RegisterDto model)
        {
            var result = await _identityService.CreateUserAndAddToRoleAsync(model);
            if (result.Result.Succeeded)
                return Ok(result.UserId);
            

            return BadRequest(result.Result);
        }
    }
}
