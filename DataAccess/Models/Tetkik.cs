using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Tetkik
{
    public int TetkikId { get; set; }

    public string TetkikAdi { get; set; } = null!;

    public string? TetkikKodu { get; set; }

    public string? Aciklama { get; set; }

    public string? Birim { get; set; }

    public decimal? NormalDegerMin { get; set; }

    public decimal? NormalDegerMax { get; set; }

    public bool? Aktif { get; set; }

    public DateTime? OlusturmaTarihi { get; set; }

    public virtual ICollection<TetkikTalep> TetkikTaleps { get; set; } = new List<TetkikTalep>();
}
