using Contacts.Data.Context;
using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.Repositorys
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AppDbContext _context;

        public TokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool BuscaUsuarioPorId(UserJwtToken userObj)
        {
            return _context.UserJwtToken.AsNoTracking().Any(user => user.Username.Equals(userObj.Username) && user.Password.Equals(userObj.Password));
        }
    }
}
