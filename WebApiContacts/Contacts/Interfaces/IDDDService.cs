using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Domain.Interfaces
{
    public interface IDDDService
    {
        Task<List<DDD>> BuscaTodosDDDs();
        Task<DDDViewModel> BuscaDDDPorId(int id);
        Task<DDD> CriaDDD(DDDViewModel dDD);
        Task<DDD> AtualizaDDD(DDDViewUpdateModel dDD);
        Task<bool> DeletaDDD(int id);
    }
}
