using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Bolum
{
    public int BolumId { get; set; }

    public int? HastaneId { get; set; }

    public string BolumAdi { get; set; } = null!;

    public string? Aciklama { get; set; }

    public bool? Aktif { get; set; }

    public DateTime? OlusturmaTarihi { get; set; }

    public virtual ICollection<Doktor> Doktors { get; set; } = new List<Doktor>();

    public virtual Hastane? Hastane { get; set; }

    public virtual ICollection<YatakliServi> YatakliServis { get; set; } = new List<YatakliServi>();
}
