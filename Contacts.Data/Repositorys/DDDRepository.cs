using Contacts.Data.Context;
using Contacts.Data.Utils;
using Contacts.Domain.Interfaces;
using Contacts.Domain.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

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
            return await Task.FromResult(_context.DDDs.ToList());
        }

        public async Task<DDD> BuscaDDDPorId(int id)
        {
           return await Task.FromResult(CacheManager.ObterOuDefinirCache("BuscaDDDPorId", () => 
            _context.DDDs.Where(d => d.DDDId == id).AsNoTracking().FirstOrDefault() ?? 
            throw new KeyNotFoundException("DDD não encontrado"), DateTimeOffset.UtcNow.AddMinutes(10)));
        }

        public async Task<DDD> CriaDDD(DDD DDD)
        {
            _context.DDDs.Add(DDD);
            _context.SaveChanges();

            return await Task.FromResult(DDD);
        }

        public async Task<DDD> AtualizaDDD(DDD dDD)
        {
            _context.DDDs.Update(dDD);
            await _context.SaveChangesAsync();

            return await Task.FromResult(dDD);
        }

        public async Task<bool> DeletaDDD(int id)
        {
            var ddd = BuscaDDDPorId(id);

            if (ddd == null) return false;

            _context.DDDs.Remove(await ddd);
            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
