using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiContacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenJwtController : ControllerBase
    {
        private readonly IAccountService _accountservice;

        public TokenJwtController(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }
             

        [HttpPost("Register")]
        public async Task<ActionResult<UserToken>> Register([FromBody] UserInfo model)
        {
            return await _accountservice.Register(model);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            return await _accountservice.LoginAsync(userInfo);
        }
    }
}
