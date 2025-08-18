using CUENSA.Models.Entities.BdSicuensa;
using CUENSA.Models.ModelsCuensa;

namespace CUENSA.Repositories.Interfaces;

public interface ICommon
{
    Task<List<TbInstalacion>> GetAllAsync();
    Task<TbInstalacion?> GetByIdAsync(int id);
    Task AddAsync(TbInstalacion instalacion);
    Task UpdateAsync(TbInstalacion instalacion);
    Task DeleteAsync(int id);
    
}