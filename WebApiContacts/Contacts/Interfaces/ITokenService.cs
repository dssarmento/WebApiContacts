using Contacts.Domain.Models;

namespace Contacts.Domain.Interfaces
{
    public interface ITokenService
    {
       string GetToken(UserJwtToken user);
    }
}
