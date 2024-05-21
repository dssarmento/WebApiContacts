using Contacts.Domain.Models;
using System.Collections.Generic;

namespace Contacts.Domain.Interfaces
{
    public interface IContatoRepository
    {
        List<Contato> BuscaTodosContatos();
        Contato BuscaContatoPorId(int id);
        List<Contato> BuscaContatosPorDDDId(int id);
        List<Contato> BuscaContatosPorDDDNome(string Nome);
        Contato CriaContato(Contato contato);
        Contato AtualizaContato(Contato contato);
        bool DeletaContato(int id);
    }
}
