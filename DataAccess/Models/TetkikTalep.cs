using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class TetkikTalep
{
    public int TalepId { get; set; }

    public int? MuayeneId { get; set; }

    public int? TetkikId { get; set; }

    public int? HastaId { get; set; }

    public int? DoktorId { get; set; }

    public DateTime? TalepTarihi { get; set; }

    public string? Aciklama { get; set; }

    public string? Durum { get; set; }

    public virtual Doktor? Doktor { get; set; }

    public virtual Hastum? Hasta { get; set; }

    public virtual Muayene? Muayene { get; set; }

    public virtual Tetkik? Tetkik { get; set; }

    public virtual ICollection<TetkikSonuc> TetkikSonucs { get; set; } = new List<TetkikSonuc>();
}
