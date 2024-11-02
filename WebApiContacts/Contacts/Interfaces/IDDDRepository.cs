using Contacts.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Domain.Interfaces
{
    public interface IDDDRepository
    {
        Task<List<DDD>> BuscaTodosDDDs();
        Task<DDD> BuscaDDDPorId(int id);
        Task<DDD> CriaDDD(DDD dDD);
        Task<DDD> AtualizaDDD(DDD dDD);
        Task<bool> DeletaDDD(int id);
    }
}
