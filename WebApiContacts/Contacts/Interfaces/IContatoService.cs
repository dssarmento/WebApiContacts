using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;
using System.Collections.Generic;

namespace Contacts.Domain.Interfaces
{
    public interface IContatoService
    {
        List<Contato> BuscaContatoPorDDDId(int id);
        List<Contato> BuscaContatoPorDDDNome(string Nome);
        List<Contato> BuscaTodosContatos();
        Contato BuscaContatoPorId(int id);
        Contato CriaNovoContato(ContatoViewModel contato);
        Contato AtualizaContato(ContatoViewUpdateModel contato);
        bool DeletaContato(int id);
    }
}
