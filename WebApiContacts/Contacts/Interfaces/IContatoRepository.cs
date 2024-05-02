using Contacts.Domain.Models;
using System.Collections.Generic;

namespace Contacts.Domain.Interfaces
{
    public interface IContatoRepository
    {
        IList<Contato> BuscaTodosContatos();
        Contato BuscaContatoPorId(int id);
        IList<Contato> BuscaContatosPorDDDId(int id);
        IList<Contato> BuscaContatosPorDDDNome(string Nome);
        Contato CriaContato(Contato contato);
        Contato AtualizaContato(Contato contato);
        bool DeletaContato(int id);
    }
}
