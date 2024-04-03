using Contacts.Domain.ModelsView;
using WebApiContacts.Domain.Recursos;
using System.Collections.Generic;
using Contacts.Domain.Interfaces;
using Contacts.Data.Context;
using Contacts.Domain.Models;

namespace Contacts.Service.Services
{
    public class DDDService : IDDDService
    {
        private readonly IDDDRepository _dDDRepository;

        public DDDService(IDDDRepository dDDRepository)
        {
            _dDDRepository = dDDRepository;
        }
        public DDD Delete(int id)
        {
            return _dDDRepository.Delete(id);
        }

        public List<DDD> GetAll()
        {
            return _dDDRepository.GetAll();
        }

        public DDD GetById(int id)
        {
            return _dDDRepository.GetById(id);
        }

        public DDDRetornoView Post(DDDView dDD)
        {
            return _dDDRepository.Post(dDD);
        }

        public DDDRetornoView Put(DDDRetornoView dDD)
        {
            return _dDDRepository.Put(dDD);
        }
    }
}
