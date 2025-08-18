using System;
using System.Collections.Generic;

namespace CUENSA.Models.Entities.BdSicuensa;

public partial class TbClasificacion
{
    public int Id { get; set; }

    public int? CodigoShaId { get; set; }

    public string? CodigoSha { get; set; }

    public string? DescripcionSha { get; set; }

    public string? InstalacionesMinsaCss { get; set; }

    public string? Observaciones { get; set; }

    public string? F6 { get; set; }
}
