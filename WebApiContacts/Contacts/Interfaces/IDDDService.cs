using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;
using System.Collections.Generic;

namespace Contacts.Domain.Interfaces
{
    public interface IDDDService
    {
        List<DDD> BuscaTodosDDDs();
        DDDViewModel BuscaDDDPorId(int id);
        DDD CriaDDD(DDDViewModel dDD);
        DDD AtualizaDDD(DDDViewUpdateModel dDD);
        bool DeletaDDD(int id);
    }
}
