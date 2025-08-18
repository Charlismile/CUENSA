using System.ComponentModel.DataAnnotations;

namespace CUENSA.Models.ModelsCuensa;

public class InstalacionModel
{
    [Required(ErrorMessage = "El nombre de la instalación es obligatorio.")]
    [StringLength(200, ErrorMessage = "El nombre no puede superar los 200 caracteres.")]
    public string? NombreInstalacion { get; set; }

    [Required(ErrorMessage = "Debe indicar el nivel de la instalación.")]
    [StringLength(100)]
    public string? NivelInstalacion { get; set; }

    [Required(ErrorMessage = "Debe indicar el tipo de instalación.")]
    [StringLength(100)]
    public string? TipoInstalacion { get; set; }
}