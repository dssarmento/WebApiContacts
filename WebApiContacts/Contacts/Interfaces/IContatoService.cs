using Contacts.Domain.ModelsView;
using System.Collections.Generic;

namespace Contacts.Domain.Interfaces
{
    public interface IContatoService
    {
        IList<ContatoViewModel> BuscaContatoPorDDDId(int id);
        IList<ContatoViewModel> BuscaContatoPorDDDNome(string Nome);
        IList<ContatoViewModel> BuscaTodosContatos();
        ContatoViewModel BuscaContatoPorId(int id);
        ContatoViewModel CriaNovoContato(ContatoViewModel contato);
        ContatoViewModel AtualizaContato(ContatoViewModel contato);
        bool DeletaContato(int id);
    }
}
