using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Randevu
{
    public int RandevuId { get; set; }

    public int? HastaId { get; set; }

    public int? DoktorId { get; set; }

    public DateTime RandevuTarihi { get; set; }

    public int? RandevuSuresi { get; set; }

    public string? Durum { get; set; }

    public string? NotBilgisi { get; set; }

    public DateTime? OlusturmaTarihi { get; set; }

    public virtual Doktor? Doktor { get; set; }

    public virtual Hastum? Hasta { get; set; }

    public virtual ICollection<Muayene> Muayenes { get; set; } = new List<Muayene>();
}
