using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Ilac
{
    public int IlacId { get; set; }

    public string IlacAdi { get; set; } = null!;

    public string? EtkenMadde { get; set; }

    public string? Form { get; set; }

    public string? Doz { get; set; }

    public string? UreticiFirma { get; set; }

    public bool? Aktif { get; set; }

    public DateTime? OlusturmaTarihi { get; set; }

    public virtual ICollection<ReceteDetay> ReceteDetays { get; set; } = new List<ReceteDetay>();
}
