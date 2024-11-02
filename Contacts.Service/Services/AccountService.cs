using Contacts.Domain.ModelsView;
using WebApiContacts.Domain.Recursos;
using System.Collections.Generic;
using Contacts.Domain.Interfaces;
using Contacts.Data.Context;
using Contacts.Domain.Models;
using Contacts.Data.Repositorys;

namespace Contacts.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<UserToken> Register(UserInfo model)
        {
            return await _accountRepository.Register(model);
        }

        public async Task<UserToken> LoginAsync(UserInfo model)
        {
            return await _accountRepository.LoginAsync(model);
        }
    }
}
