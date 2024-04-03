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
    public  class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext context;

        public ContatoRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Contato Delete(int id)
        {
            var Contato = new Contato { ContatoId = id };
            context.Remove(Contato);
            context.SaveChangesAsync();
            return Contato;
        }

        public List<Contato> GetAll()
        {
            return context.Contatos.ToList();
        }

        public Contato GetById(int id)
        {
            return (Contato)context.Contatos.Where(x => x.ContatoId == id);
        }

        public List<Contato> GetContatosDDDId(int id)
        {
            return  context.Contatos.Where(p => p.DDDId == id).ToList();
        }

        public List<Contato> GetContatosDDDNome(string Nome)
        {
            var listContatos = (from Co in context.Contatos
                                join Dd in context.DDDs on Co.DDDId equals Dd.DDDId
                                where Dd.Nome.Trim().ToUpper().ToString() == Nome.Trim().ToUpper().ToString()
                                select new Contato()
                                {
                                    ContatoId = Co.ContatoId,
                                    Nome = Co.Nome,
                                    Telefone = Co.Telefone,
                                    Email =Co.Email,
                                    DDDId = Co.DDDId
                                }).ToList();

            return listContatos;
        }

        public ContatoRetornoView Post(ContatoView contato)
        {
            Contato ddados = new Contato();
            ddados.Nome = contato.Nome;
            ddados.Telefone = contato.Telefone;
            ddados.Email = contato.Email;
            ddados.DDDId = contato.DDDId;

            context.Add(ddados);
            context.SaveChangesAsync();

            ContatoRetornoView dretorno = new ContatoRetornoView();
            dretorno.Nome = ddados.Nome;
            dretorno.Telefone = ddados.Telefone;
            dretorno.Email = ddados.Email;
            dretorno.DDDId = ddados.DDDId;
            return dretorno;
        }

        public ContatoRetornoView Put(ContatoRetornoView contato)
        {
            Contato ddados = new Contato();
            ddados.ContatoId = contato.ContatoId;
            ddados.Nome = contato.Nome;
            ddados.Telefone = contato.Telefone;
            ddados.Email = contato.Email;
            ddados.DDDId = contato.DDDId;

            context.Entry(ddados).State = EntityState.Modified;
            context.SaveChangesAsync();
            return contato;
        }
    }
}
