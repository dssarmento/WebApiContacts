using Contacts.Domain.Models;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Domain.ModelsView;
using WebApiContacts.Domain.Recursos;
using System.Collections.Generic;

namespace Contacts.Domain.Interfaces
{
    public interface IDDDService
    {
        List<DDD> GetAll();
        DDD GetById(int id);
        DDDRetornoView Post(DDDView dDD);
        DDDRetornoView Put(DDDRetornoView dDD);
        DDD Delete(int id);
    }
}
