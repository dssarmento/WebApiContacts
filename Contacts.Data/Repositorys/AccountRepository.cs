using Contacts.Data.Context;
using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Contacts.Data.Repositorys
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext context;
        public AccountRepository(
                                 UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager,
                                 IConfiguration configuration,
                                 AppDbContext context
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            this.context = context;
        }

        public async Task<UserToken> Register(UserInfo model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };


            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Incluir o novo usuário ao perfil User
                await _userManager.AddToRoleAsync(user, "User");

                //incluir um novo usuário com email que começa com admin no perfil Admin
                if (user.Email.ToUpper().StartsWith("A"))
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                return await GenerateTokenAsync(model);
            }
            else
            {
                var expiration = DateTime.UtcNow.AddHours(2);
                return new UserToken()
                {
                    Token = "",
                    Expiration = expiration,
                    Message = "Senha ou nome do usuário inválidos..."
                };
            }
        }

        public async Task<UserToken> LoginAsync(UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email,
               userInfo.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await GenerateTokenAsync(userInfo);
            }
            else
            {
                var expiration = DateTime.UtcNow.AddHours(2);
                return new UserToken()
                {
                    Token = "",
                    Expiration = expiration,
                    Message = "Login Inválido"
                };
            }
        }

        private async Task<UserToken> GenerateTokenAsync(UserInfo userInfo)
        {

            var user = await _signInManager.UserManager.FindByEmailAsync(userInfo.Email);
            var roles = await _signInManager.UserManager.GetRolesAsync(user);
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userInfo.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:SecretJWT"]));
            var creds =
               new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(2);
            var message = "Token JWT criado com sucesso";

            JwtSecurityToken token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = message
            };
        }
    }
}
