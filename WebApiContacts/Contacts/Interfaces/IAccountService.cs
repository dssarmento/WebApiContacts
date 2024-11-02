using Contacts.Domain.Models;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Domain.ModelsView;
using WebApiContacts.Domain.Recursos;
using System.Collections.Generic;


namespace Contacts.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<UserToken> Register(UserInfo model);
        Task<UserToken> LoginAsync(UserInfo userInfo);
    }
}
