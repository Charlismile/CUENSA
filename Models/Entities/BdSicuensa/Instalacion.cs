using System;
using System.Collections.Generic;

namespace SICUENSA.Models.Entities.BdSicuensa;

public partial class Instalacion
{
    public double? InstalacionSaludId { get; set; }

    public string? InstalacionSalud { get; set; }

    public double? CodigoInstalacion { get; set; }

    public string? TipoInstalacion { get; set; }

    public double? TipoInstalacionId { get; set; }

    public string? ClasificacionCdSSha { get; set; }

    public double? ClasificacionCtasNacId { get; set; }

    public double? NivelInstalacionId { get; set; }

    public string? NivelInstalacion { get; set; }

    public double? TitularidadInstalacionId { get; set; }

    public string? TitularidadInstalacion { get; set; }

    public double? DependenciaInstalacionId { get; set; }

    public string? CodigoSha1 { get; set; }

    public string? CodigoSha2 { get; set; }

    public string? CodigoSha3 { get; set; }

    public string? CodigoSha4 { get; set; }

    public string? DependenciaInstalacion { get; set; }

    public string? NomenclaturaSha { get; set; }
}
