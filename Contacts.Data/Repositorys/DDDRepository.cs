using Contacts.Data.Context;
using Contacts.Data.Utils;
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

        public List<DDD> BuscaTodosDDDs()
        {
            return _context.DDDs.ToList();
        }

        public DDD BuscaDDDPorId(int id)
        {
           return CacheManager.ObterOuDefinirCache("BuscaDDDPorId", () => 
            _context.DDDs.Where(d => d.DDDId == id).AsNoTracking().FirstOrDefault() ?? 
            throw new KeyNotFoundException("DDD não encontrado"), DateTimeOffset.UtcNow.AddMinutes(10));
        }

        public DDD CriaDDD(DDD DDD)
        {
            _context.DDDs.Add(DDD);
            _context.SaveChanges();

            return DDD;
        }

        public DDD AtualizaDDD(DDD dDD)
        {
            _context.DDDs.Update(dDD);
            _context.SaveChangesAsync();

            return dDD;
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
