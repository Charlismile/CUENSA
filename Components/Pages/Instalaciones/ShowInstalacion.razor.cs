using CUENSA.Models.Entities.BdSicuensa;
using CUENSA.Repositories.Services;
using Microsoft.AspNetCore.Components;

namespace CUENSA.Components.Pages.Instalaciones;

public partial class ShowInstalacion : ComponentBase
{
    // Filtros
    private string FilterNombre = "";
    private string FilterNivel = "";

    // Listas
    private List<TbInstalacion> Instalaciones = new();
    private List<TbInstalacion> FilteredInstalaciones = new(); // Ahora es un campo, no una expresión

    // Estado para formularios
    private TbInstalacion NewInstalacion = new(); // ✅ Declarado
    private TbInstalacion? EditingInstalacion; // ✅ Declarado

    // Mensajes
    private string StatusMessage = "";
    private string StatusMessageType = "";

    protected override async Task OnInitializedAsync()
    {
        
        await RefreshData();
        ApplyFilters();
    }

    private void ClearFilters()
    {
        FilterNombre = "";
        FilterNivel = "";
        ApplyFilters();
    }

    private async Task AddInstalacion()
    {
        await CommonService.AddAsync(NewInstalacion);
        NewInstalacion = new TbInstalacion(); // Reiniciar
        await RefreshData();
        ShowMessage("Instalación agregada correctamente", "success");
    }

    private void StartEdit(TbInstalacion item)
    {
        EditingInstalacion = new TbInstalacion
        {
            InstalacionId = item.InstalacionId,
            NombreInstalacion = item.NombreInstalacion,
            NivelInstalacion = item.NivelInstalacion,
            TipoInstalacion = item.TipoInstalacion
        };
        StateHasChanged(); // Asegura que el modal se muestre
    }

    private async Task SaveEdit()
    {
        if (EditingInstalacion != null)
        {
            await CommonService.UpdateAsync(EditingInstalacion);
            EditingInstalacion = null;
            await RefreshData();
            ShowMessage("Instalación actualizada correctamente", "success");
        }
    }

    private async Task DeleteInstalacion(int id)
    {
        await CommonService.DeleteAsync(id);
        await RefreshData();
        ShowMessage("Instalación eliminada", "success");
    }

    private void CancelEdit()
    {
        EditingInstalacion = null;
        StateHasChanged();
    }

    private async Task RefreshData()
    {
        Instalaciones = await CommonService.GetAllAsync();
        ApplyFilters(); // Aplicar filtros tras cargar datos
    }

    private void ApplyFilters()
    {
        FilteredInstalaciones = Instalaciones
            .Where(i =>
                (string.IsNullOrWhiteSpace(FilterNombre) ||
                 i.NombreInstalacion.Contains(FilterNombre, StringComparison.OrdinalIgnoreCase)) &&
                i.NivelInstalacion != null &&
                (string.IsNullOrWhiteSpace(FilterNivel) ||
                 i.NivelInstalacion.Equals(FilterNivel, StringComparison.OrdinalIgnoreCase))
            )
            .ToList();

        StateHasChanged(); // Actualiza la UI
    }

    private void OnFilterChanged() => ApplyFilters();

    private void ShowMessage(string message, string type)
    {
        StatusMessage = message;
        StatusMessageType = type;
        StateHasChanged();

        // Ocultar mensaje después de 3 segundos
        _ = Task.Delay(3000).ContinueWith(_ =>
        {
            if (StatusMessage == message) // Solo limpiar si sigue siendo el mismo
            {
                StatusMessage = "";
                StateHasChanged();
            }
        }, TaskScheduler.Default);
    }
}