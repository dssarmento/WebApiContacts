using Contacts.Domain.ModelsView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contacts.Domain.Models;
using WebApiContacts.Domain.Recursos;

namespace Contacts.Domain.Interfaces
{
    public interface IContatoRepository
    {
        List<Contato> GetContatosDDDId(int id);
        List<Contato> GetContatosDDDNome(string Nome);
        List<Contato> GetAll();
        Contato GetById(int id);
        ContatoRetornoView Post(ContatoView contato);
        ContatoRetornoView Put(ContatoRetornoView contato);
        Contato Delete(int id);
    }
}
