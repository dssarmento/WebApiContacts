using Contacts.Domain.Models;

namespace Contacts.Domain.Interfaces
{
    public interface ITokenRepository
    {
        bool BuscaUsuarioPorId(UserJwtToken user);
    }
}
