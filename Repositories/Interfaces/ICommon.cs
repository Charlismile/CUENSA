using CUENSA.Models.Entities.BdSicuensa;
using CUENSA.Models.ModelsCuensa;

namespace CUENSA.Repositories.Interfaces;

public interface ICommon
{
    //Totales
    Task<int> GetTotalInstalacionesAsync();
    Task<int> GetTotalClasificacionesAsync();
    
    Task<int> GetTotalRegionesAsync();
    Task<int> GetTotalDistritosAsync();
    Task<int> GetTotalCorregimientosAsync();
    Task<int> GetTotalProvinciasAsync();
    Task<int> GetTotalRegistrosAsync();
    
    // Agrupaciones
    Task<Dictionary<string, int>> GetInstalacionesPorProvinciaAsync();
    Task<Dictionary<string, int>> GetClasificacionesShaAsync();
}