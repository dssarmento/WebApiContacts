using Contacts.Data.Context;
using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.Repositorys
{
    public class DDDRepository : IDDDRepository
    {
        private readonly AppDbContext _context;

        public DDDRepository(AppDbContext context)
        {
            _context = context;
        }

        public IList<DDD> BuscaTodosDDDs()
        {
            return _context.DDDs.AsNoTracking().ToList();
        }

        public DDD BuscaDDDPorId(int id)
        {
            return _context.DDDs.Where(d => d.DDDId == id).AsNoTracking().FirstOrDefault() ?? 
                throw new KeyNotFoundException("DDD não encontrado");
        }

        public DDD CriaDDD(DDD DDD)
        {
            _context.DDDs.Add(DDD);
            _context.SaveChanges();

            return DDD;
        }

        public DDD AtualizaDDD(DDD DDD)
        {
            _context.DDDs.Update(DDD);
            _context.SaveChangesAsync();

            return DDD;
        }

        public bool DeletaDDD(int id)
        {
            var ddd = BuscaDDDPorId(id);

            if (ddd == null) return false;

            _context.DDDs.Remove(ddd);
            _context.SaveChangesAsync();

            return true;
        }
    }
}
