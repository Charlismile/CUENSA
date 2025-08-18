using System;
using System.Collections.Generic;

namespace CUENSA.Models.Entities.BdSicuensa;

public partial class TbInstalacion
{
    public int InstalacionId { get; set; }

    public string NombreInstalacion { get; set; } = null!;

    public int? CodigoInstalacion { get; set; }

    public string? TipoInstalacion { get; set; }

    public int? TipoInstalacionId { get; set; }

    public string? ClasificacionCdSSha { get; set; }

    public int? ClasificacionCtasNacId { get; set; }

    public int? NivelInstalacionId { get; set; }

    public string? NivelInstalacion { get; set; }

    public int? TitularidadInstalacionId { get; set; }

    public string? TitularidadInstalacion { get; set; }

    public int? DependenciaInstalacionId { get; set; }

    public string? CodigoSha1 { get; set; }

    public string? CodigoSha2 { get; set; }

    public string? CodigoSha3 { get; set; }

    public string? CodigoSha4 { get; set; }

    public string? DependenciaInstalacion { get; set; }

    public string? NomenclaturaSha { get; set; }

    public virtual ICollection<TbSha1> TbSha1 { get; set; } = new List<TbSha1>();

    public virtual ICollection<TbSha2> TbSha2 { get; set; } = new List<TbSha2>();

    public virtual ICollection<TbSha3> TbSha3 { get; set; } = new List<TbSha3>();

    public virtual ICollection<TbSha4> TbSha4 { get; set; } = new List<TbSha4>();
}
