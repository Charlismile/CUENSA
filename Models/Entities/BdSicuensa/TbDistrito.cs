using System;
using System.Collections.Generic;

namespace CUENSA.Models.Entities.BdSicuensa;

public partial class TbDistrito
{
    public int DistritoId { get; set; }

    public string NombreDistrito { get; set; } = null!;

    public int ProvinciaId { get; set; }

    public virtual TbProvincia Provincia { get; set; } = null!;

    public virtual ICollection<TbCorregimiento> TbCorregimiento { get; set; } = new List<TbCorregimiento>();
}
