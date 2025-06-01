using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ReceteDetay
{
    public int DetayId { get; set; }

    public int? ReceteId { get; set; }

    public int? IlacId { get; set; }

    public int Miktar { get; set; }

    public string? KullanimSekli { get; set; }

    public int? GunSayisi { get; set; }

    public string? Aciklama { get; set; }

    public virtual Ilac? Ilac { get; set; }

    public virtual Recete? Recete { get; set; }
}
