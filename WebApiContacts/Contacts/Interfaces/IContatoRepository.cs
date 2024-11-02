using Contacts.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Domain.Interfaces
{
    public interface IContatoRepository
    {
        Task<List<Contato>> BuscaTodosContatos();
        Task<Contato> BuscaContatoPorId(int id);
        Task<List<Contato>> BuscaContatosPorDDDId(int id);
        Task<List<Contato>> BuscaContatosPorDDDNome(string Nome);
        Task<Contato> CriaContato(Contato contato);
        Task<Contato> AtualizaContato(Contato contato);
        Task<bool> DeletaContato(int id);
    }
}
