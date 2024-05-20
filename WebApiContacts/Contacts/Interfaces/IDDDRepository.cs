using Contacts.Domain.Models;
using System.Collections.Generic;

namespace Contacts.Domain.Interfaces
{
    public interface IDDDRepository
    {
        List<DDD> BuscaTodosDDDs();
        DDD BuscaDDDPorId(int id);
        DDD CriaDDD(DDD dDD);
        DDD AtualizaDDD(DDD dDD);
        bool DeletaDDD(int id);
    }
}
