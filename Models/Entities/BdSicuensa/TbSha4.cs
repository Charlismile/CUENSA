using System;
using System.Collections.Generic;

namespace CUENSA.Models.Entities.BdSicuensa;

public partial class TbSha4
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public int Sha3Id { get; set; }

    public int Sha2Id { get; set; }

    public int Sha1Id { get; set; }

    public int InstalacionId { get; set; }

    public virtual TbInstalacion Instalacion { get; set; } = null!;

    public virtual TbSha1 Sha1 { get; set; } = null!;

    public virtual TbSha2 Sha2 { get; set; } = null!;

    public virtual TbSha3 Sha3 { get; set; } = null!;
}
