using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenJwtController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenJwtController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Token([FromBody] UserJwtToken usuario)
        {
            var token = _tokenService.GetToken(usuario);

            if (!string.IsNullOrWhiteSpace(token))
            {
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
