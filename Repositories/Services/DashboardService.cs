using Microsoft.EntityFrameworkCore;
using SICUENSA.Models.Entities.BdSicuensa;

namespace SICUENSA.Repositories.Services;

public class DashboardService
{
    private readonly DbContextSicuensa _db;

    public DashboardService(DbContextSicuensa db) => _db = db;

    public async Task<Dictionary<string, int>> GetCountByLevelAsync()
    {
        return await _db.Instalaciones
            .GroupBy(i => i.NivelInstalacion)
            .Select(g => new { Level = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.Level, x => x.Count);
    }

    public async Task<Dictionary<string, int>> GetCountByTypeAsync()
    {
        return await _db.Instalaciones
            .GroupBy(i => i.TipoInstalacion)
            .Select(g => new { Type = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.Type, x => x.Count);
    }
}