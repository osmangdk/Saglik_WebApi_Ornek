using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Yatak
{
    public int YatakId { get; set; }

    public int? ServisId { get; set; }

    public string YatakNo { get; set; } = null!;

    public string? OdaNo { get; set; }

    public string? YatakTipi { get; set; }

    public string? Durum { get; set; }

    public bool? Aktif { get; set; }

    public virtual YatakliServi? Servis { get; set; }

    public virtual ICollection<Yati> Yatis { get; set; } = new List<Yati>();
}
