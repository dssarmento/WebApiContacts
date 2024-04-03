using Contacts.Domain.ModelsView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contacts.Domain.Models;
using WebApiContacts.Domain.Recursos;

namespace Contacts.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<UserToken> Register(UserInfo model);
        Task<UserToken> LoginAsync(UserInfo userInfo);
    }
}
