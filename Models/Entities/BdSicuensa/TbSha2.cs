using System;
using System.Collections.Generic;

namespace CUENSA.Models.Entities.BdSicuensa;

public partial class TbSha2
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public int Sha1Id { get; set; }

    public int InstalacionId { get; set; }

    public virtual TbInstalacion Instalacion { get; set; } = null!;

    public virtual TbSha1 Sha1 { get; set; } = null!;

    public virtual ICollection<TbSha3> TbSha3 { get; set; } = new List<TbSha3>();

    public virtual ICollection<TbSha4> TbSha4 { get; set; } = new List<TbSha4>();
}
