using Contacts.Domain.Models;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Domain.ModelsView;
using WebApiContacts.Domain.Recursos;
using System.Collections.Generic;
using Contacts.Domain.Interfaces;
using Contacts.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Contacts.Data.Utils;

namespace Contacts.Data.Repositorys
{
    public class DDDRepository : IDDDRepository
    {
        private readonly AppDbContext context;

        public DDDRepository(AppDbContext context)
        {
            this.context = context;
        }

        public DDD Delete(int id)
        {
            var dDD = new DDD { DDDId = id };
            context.Remove(dDD);
            context.SaveChangesAsync();
            return dDD;
        }

        public List<DDD> GetAll()
        {
            return context.DDDs.ToList();
        }

        public DDD GetById(int id)
        {
            return (DDD)context.DDDs.Where(x => x.DDDId == id);
        }

        public DDDRetornoView Post(DDDView dDD)
        {
            DDD ddados = new DDD();
            ddados.Nome = dDD.Nome;

            context.Add(ddados);
            context.SaveChangesAsync();

            DDDRetornoView dretorno = new DDDRetornoView();
            dretorno.DDDId = ddados.DDDId;
            dretorno.Nome = ddados.Nome;
            return dretorno;
        }

        public DDDRetornoView Put(DDDRetornoView dDD)
        {
            DDD ddados = new DDD();
            ddados.DDDId = dDD.DDDId;
            ddados.Nome = dDD.Nome;

            context.Entry(ddados).State = EntityState.Modified;
            context.SaveChangesAsync();

            return dDD;
        }
    }
}
