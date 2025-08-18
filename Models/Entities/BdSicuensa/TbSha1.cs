using System;
using System.Collections.Generic;

namespace CUENSA.Models.Entities.BdSicuensa;

public partial class TbSha1
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public int InstalacionId { get; set; }

    public virtual TbInstalacion Instalacion { get; set; } = null!;

    public virtual ICollection<TbSha2> TbSha2 { get; set; } = new List<TbSha2>();

    public virtual ICollection<TbSha3> TbSha3 { get; set; } = new List<TbSha3>();

    public virtual ICollection<TbSha4> TbSha4 { get; set; } = new List<TbSha4>();
}
