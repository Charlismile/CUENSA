using CUENSA.Models.Entities.BdSicuensa;
using CUENSA.Models.ModelsCuensa;
using CUENSA.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace CUENSA.Repositories.Services;

public class CommonServices : ICommon
{
    private readonly IDbContextFactory<DbContextSicuensa> _contextFactory;

    public CommonServices(IDbContextFactory<DbContextSicuensa> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<TbInstalacion>> GetAllAsync()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return await ctx.TbInstalacion.OrderBy(x => x.NombreInstalacion).ToListAsync();
    }

    public async Task<TbInstalacion?> GetByIdAsync(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return await ctx.TbInstalacion.FindAsync(id);
    }

    public async Task AddAsync(TbInstalacion instalacion)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        ctx.TbInstalacion.Add(instalacion);
        await ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(TbInstalacion instalacion)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        ctx.TbInstalacion.Update(instalacion);
        await ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var entity = await ctx.TbInstalacion.FindAsync(id);
        if (entity != null)
        {
            ctx.TbInstalacion.Remove(entity);
            await ctx.SaveChangesAsync();
        }
    }
    
}