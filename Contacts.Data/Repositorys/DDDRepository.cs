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

        public async Task<List<DDD>> BuscaTodosDDDs()
        {
            return await _context.DDDs.ToListAsync();
        }

        public async Task<DDD> BuscaDDDPorId(int id)
        {
           return await _context.DDDs.Where(d => d.DDDId == id).AsNoTracking().FirstOrDefaultAsync() ?? 
                throw new KeyNotFoundException("DDD não encontrado");
        }

        public async Task<DDD> CriaDDD(DDD DDD)
        {
            _context.DDDs.Add(DDD);
            await _context.SaveChangesAsync();

            return DDD;
        }

        public async Task<DDD> AtualizaDDD(DDD dDD)
        {
            _context.DDDs.Update(dDD);
            await _context.SaveChangesAsync();

            return dDD;
        }

        public async Task<bool> DeletaDDD(int id)
        {
            var ddd = BuscaDDDPorId(id);

            if (ddd == null) return false;

            _context.DDDs.Remove(await ddd);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
