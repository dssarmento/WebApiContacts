using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;
using System.Collections.Generic;

namespace Contacts.Domain.Interfaces
{
    public interface IDDDService
    {
        IList<DDDViewModel> BuscaTodosDDDs();
        DDDViewModel BuscaDDDPorId(int id);
        DDDViewModel CriaDDD(DDDViewModel dDD);
        DDDViewModel AtualizaDDD(DDDViewModel dDD);
        bool DeletaDDD(int id);
    }
}
