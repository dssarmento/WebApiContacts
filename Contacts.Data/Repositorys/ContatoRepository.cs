using Contacts.Data.Context;
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

        public async Task<List<Contato>> BuscaTodosContatos()
        {
            var listContatos = await (from Co in _context.Contatos
                                join Dd in _context.DDDs on Co.DDDId equals Dd.DDDId
                                select new Contato()
                                {
                                    ContatoId = Co.ContatoId,
                                    Nome = Co.Nome,
                                    Telefone = Co.Telefone,
                                    Email = Co.Email,
                                    DDDId = Co.DDDId,
                                    DDD = Co.DDD
                                }).ToListAsync();

            return  listContatos;
        }

        public async Task<Contato> BuscaContatoPorId(int id)
        {

            var contato = await (from Co in _context.Contatos
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
                           }).FirstAsync();


            return contato;
        }

        public async Task<List<Contato>> BuscaContatosPorDDDId(int id)
        {
            var listContatos = await (from Co in _context.Contatos
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
                                }).ToListAsync();

            return listContatos;
        }

        public async Task<List<Contato>> BuscaContatosPorDDDNome(string Nome)
        {
            var listContatos = await (from Co in _context.Contatos
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
                                }).ToListAsync();

            return listContatos;
        }

        public async Task<Contato> CriaContato(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();

            DDD vDDD = new DDD();
            vDDD = await _context.DDDs.Where(ddd => ddd.DDDId == contato.DDDId).FirstAsync();

            contato.DDD.Ddd = vDDD.Ddd;
            contato.DDD.Nome = vDDD.Nome;

            return contato;
        }

        public async Task<Contato> AtualizaContato(Contato contato)
        {
            _context.Contatos.Update(contato);
            await _context.SaveChangesAsync();
            return contato;
        }

        public async Task<bool> DeletaContato(int id)
        {
            var contato = await BuscaContatoPorId(id);

            if (contato == null) return false;

            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
