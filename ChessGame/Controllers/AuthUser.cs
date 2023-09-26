using ChessGame.Models;
using ChessGame.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUser : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthUser(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(LoginUser user)
        {
            if (await _authService.RegisterUser(user))
            {
                return Ok("Successfully");
            }
            return BadRequest("Something went Wrong");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (await _authService.Login(user))
            {  
                var tokenString = _authService.GenerateTokenString(user);
            return Ok(tokenString);
            }    
            return BadRequest();
        }
    }
}
