using Contacts.Data.Context;
using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiContacts.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountservice;
        private readonly AppDbContext context;
        public AccountController(AppDbContext context, IAccountService accountservice)
        {
            this.context = context;
            this.accountservice = accountservice;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserToken>> Register([FromBody] UserInfo model)
        {
            return await this.accountservice.Register(model);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            return await this.accountservice.LoginAsync(userInfo);
        }
    }
}