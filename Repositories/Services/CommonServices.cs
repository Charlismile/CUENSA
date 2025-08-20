using CUENSA.Models.Entities.BdSicuensa;
using CUENSA.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CUENSA.Repositories.Services;
public class CommonServices : ICommon
{
    private readonly DbContextSicuensa _context;

    public CommonServices(DbContextSicuensa context)
    {
        _context = context;
    }

    public async Task<int> GetTotalInstalacionesAsync()
    {
        return await _context.TbInstalacion.CountAsync();
    }

    public async Task<int> GetTotalClasificacionesAsync()
    {
        // Suponiendo que tienes tablas SHA1, SHA2, SHA3, SHA4
        var totalSha1 = await _context.TbSha1.CountAsync();
        var totalSha2 = await _context.TbSha2.CountAsync();
        var totalSha3 = await _context.TbSha3.CountAsync();
        var totalSha4 = await _context.TbSha4.CountAsync();

        return totalSha1 + totalSha2 + totalSha3 + totalSha4;
    }

    public async Task<int> GetTotalRegionesAsync()
    {
        return await _context.TbProvincia.CountAsync();
    }
    
    public async Task<int> GetTotalProvinciasAsync()
    {
        return await _context.TbProvincia.CountAsync();
    }

    public async Task<int> GetTotalDistritosAsync()
    {
        return await _context.TbProvincia.CountAsync();
    }
    public async Task<int> GetTotalCorregimientosAsync()
    {
        return await _context.TbProvincia.CountAsync();
    }
    public async Task<int> GetTotalRegistrosAsync()
    {
        // Aquí puedes definir qué significa "Registros Totales"
        // Por ejemplo: Instalaciones + Clasificaciones
        return await _context.TbInstalacion.CountAsync() 
               + await _context.TbSha1.CountAsync()
               + await _context.TbSha2.CountAsync()
               + await _context.TbSha3.CountAsync()
               + await _context.TbSha4.CountAsync();
    }
    
    // 🔹 Agrupación: Instalaciones por Provincia
    public async Task<Dictionary<string, int>> GetInstalacionesPorProvinciaAsync()
    {
        return await _context.TbInstalacion
            .GroupBy(i => i.NombreInstalacion) // <-- ajusta según tu modelo
            .Select(g => new { Provincia = g.Key, Total = g.Count() })
            .ToDictionaryAsync(x => x.Provincia, x => x.Total);
    }

    // 🔹 Agrupación: Clasificaciones SHA (ejemplo sumando las tablas)
    public async Task<Dictionary<string, int>> GetClasificacionesShaAsync()
    {
        var result = new Dictionary<string, int>
        {
            { "SHA1", await _context.TbSha1.CountAsync() },
            { "SHA2", await _context.TbSha2.CountAsync() },
            { "SHA3", await _context.TbSha3.CountAsync() },
            { "SHA4", await _context.TbSha4.CountAsync() }
        };

        return result;
    }
}