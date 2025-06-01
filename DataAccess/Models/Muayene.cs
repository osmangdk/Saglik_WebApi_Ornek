using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Muayene
{
    public int MuayeneId { get; set; }

    public int? RandevuId { get; set; }

    public int? HastaId { get; set; }

    public int? DoktorId { get; set; }

    public DateTime? MuayeneTarihi { get; set; }

    public string? Sikayet { get; set; }

    public string? Tani { get; set; }

    public string? TedaviPlani { get; set; }

    public string? NotBilgisi { get; set; }

    public string? Durum { get; set; }

    public virtual Doktor? Doktor { get; set; }

    public virtual Hastum? Hasta { get; set; }

    public virtual Randevu? Randevu { get; set; }

    public virtual ICollection<Recete> Recetes { get; set; } = new List<Recete>();

    public virtual ICollection<TetkikTalep> TetkikTaleps { get; set; } = new List<TetkikTalep>();
}
