using Contacts.Data.Context;
using Contacts.Data.Utils;
using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.Repositorys
{
    public  class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _context;

        public ContatoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Contato> BuscaTodosContatos()
        {
            var listContatos = (from Co in _context.Contatos
                                join Dd in _context.DDDs on Co.DDDId equals Dd.DDDId
                                select new Contato()
                                {
                                    ContatoId = Co.ContatoId,
                                    Nome = Co.Nome,
                                    Telefone = Co.Telefone,
                                    Email = Co.Email,
                                    DDDId = Co.DDDId,
                                    DDD = Co.DDD
                                }).ToList();

            return listContatos;
        }

        public Contato BuscaContatoPorId(int id)
        {

            var contato = (from Co in _context.Contatos
                           join Dd in _context.DDDs on Co.DDDId equals Dd.DDDId
                           where Co.ContatoId == id
                           select new Contato()
                           {
                               ContatoId = Co.ContatoId,
                               Nome = Co.Nome,
                               Telefone = Co.Telefone,
                               Email = Co.Email,
                               DDDId = Co.DDDId,
                               DDD = Co.DDD
                           }).FirstOrDefault();


            return contato;
        }

        public List<Contato> BuscaContatosPorDDDId(int id)
        {
            var listContatos = (from Co in _context.Contatos
                                join Dd in _context.DDDs on Co.DDDId equals Dd.DDDId
                                where Co.DDDId == id
                                select new Contato()
                                {
                                    ContatoId = Co.ContatoId,
                                    Nome = Co.Nome,
                                    Telefone = Co.Telefone,
                                    Email = Co.Email,
                                    DDDId = Co.DDDId,
                                    DDD = Co.DDD
                                }).ToList();

            return listContatos;
        }

        public List<Contato> BuscaContatosPorDDDNome(string Nome)
        {
            var listContatos = (from Co in _context.Contatos
                                join Dd in _context.DDDs on Co.DDDId equals Dd.DDDId
                                where Dd.Nome.Trim().ToUpper().ToString() == Nome.Trim().ToUpper().ToString()
                                select new Contato()
                                {
                                    ContatoId = Co.ContatoId,
                                    Nome = Co.Nome,
                                    Telefone = Co.Telefone,
                                    Email = Co.Email,
                                    DDDId = Co.DDDId,
                                    DDD = Co.DDD
                                }).ToList();


            return listContatos;
        }

        public Contato CriaContato(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();

            return contato;
        }

        public Contato AtualizaContato(Contato contato)
        {
            _context.Contatos.Update(contato);
            _context.SaveChanges();
            return contato;
        }

        public bool DeletaContato(int id)
        {
            var contato = BuscaContatoPorId(id);

            if (contato == null) return false;

            _context.Remove(contato);
            _context.SaveChangesAsync();

            return true;
        }
    }
}
