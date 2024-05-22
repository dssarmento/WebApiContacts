using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Domain.Interfaces
{
    public interface IContatoService
    {
        Task<List<Contato>> BuscaContatoPorDDDId(int id);
        Task<List<Contato>> BuscaContatoPorDDDNome(string Nome);
        Task<List<Contato>> BuscaTodosContatos();
        Task<Contato> BuscaContatoPorId(int id);
        Task<Contato> CriaNovoContato(ContatoViewModel contato);
        Task<Contato> AtualizaContato(ContatoViewUpdateModel contato);
        Task<bool> DeletaContato(int id);
    }
}
