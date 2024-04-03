using Contacts.Domain.ModelsView;
using WebApiContacts.Domain.Recursos;
using System.Collections.Generic;
using Contacts.Domain.Interfaces;
using Contacts.Data.Context;
using Contacts.Domain.Models;

namespace Contacts.Service.Services
{
    public  class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public Contato Delete(int id)
        {
            return _contatoRepository.Delete(id);
        }

        public List<Contato> GetAll()
        {
            return _contatoRepository.GetAll();
        }

        public Contato GetByID(int id)
        {
            return _contatoRepository.GetById(id);
        }

        public List<Contato> GetContatosDDDId(int id)
        {
            return _contatoRepository.GetContatosDDDId(id);
        }

        public List<Contato> GetContatosDDDNome(string Nome)
        {
            return _contatoRepository.GetContatosDDDNome(Nome);
        }

        public ContatoRetornoView Post(ContatoView contato)
        {
            return _contatoRepository.Post(contato);
        }

        ContatoRetornoView IContatoService.Put(ContatoRetornoView contato)
        {
            return _contatoRepository.Put(contato);
        }
    }
}
