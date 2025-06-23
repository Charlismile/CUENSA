using CUENSA.Models.Entities.BdSicuensa;
using Microsoft.EntityFrameworkCore;

namespace SICUENSA.Repositories.Services
{
    public class InstalacionService
    {
        private readonly DbContextSicuensa _db;

        public InstalacionService(DbContextSicuensa db) => _db = db;

        public async Task<List<Instalacion>> GetAllAsync() =>
            await _db.Instalacion.ToListAsync();

        public async Task AddAsync(Instalacion instalacion)
        {
            await _db.Instalacion.AddAsync(instalacion);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Instalacion instalacion)
        {
            _db.Instalacion.Update(instalacion);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(double id)
        {
            var item = await _db.Instalacion.FindAsync(id);
            if (item != null)
            {
                _db.Instalacion.Remove(item);
                await _db.SaveChangesAsync();
            }
        }
    }
}