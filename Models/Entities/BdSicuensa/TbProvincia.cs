using System;
using System.Collections.Generic;

namespace CUENSA.Models.Entities.BdSicuensa;

public partial class TbProvincia
{
    public int ProvinciaId { get; set; }

    public string NombreProvincia { get; set; } = null!;

    public int RegionSaludId { get; set; }

    public virtual TbRegionSalud RegionSalud { get; set; } = null!;

    public virtual ICollection<TbDistrito> TbDistrito { get; set; } = new List<TbDistrito>();
}
