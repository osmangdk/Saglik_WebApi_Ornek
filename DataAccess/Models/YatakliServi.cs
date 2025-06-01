using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class YatakliServi
{
    public int ServisId { get; set; }

    public int? HastaneId { get; set; }

    public int? BolumId { get; set; }

    public string ServisAdi { get; set; } = null!;

    public int? YatakSayisi { get; set; }

    public bool? Aktif { get; set; }

    public virtual Bolum? Bolum { get; set; }

    public virtual Hastane? Hastane { get; set; }

    public virtual ICollection<Yatak> Yataks { get; set; } = new List<Yatak>();
}
