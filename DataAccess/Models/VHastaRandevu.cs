using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class VHastaRandevu
{
    public string? HastaAdi { get; set; }

    public string? DoktorAdi { get; set; }

    public string? BolumAdi { get; set; }

    public DateTime? RandevuTarihi { get; set; }

    public string? Durum { get; set; }

    public string? NotBilgisi { get; set; }
}
