using Contacts.Domain.Models;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Domain.ModelsView;
using WebApiContacts.Domain.Recursos;
using System.Collections.Generic;

namespace Contacts.Domain.Interfaces
{
    public interface IContatoService
    {
        List<Contato> GetContatosDDDId(int id);
        List<Contato> GetContatosDDDNome(string Nome);
        List<Contato> GetAll();
        Contato GetByID(int id);
        ContatoRetornoView Post(ContatoView contato);
        ContatoRetornoView Put(ContatoRetornoView contato);
        Contato Delete(int id);
    }
}
