using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Recete
{
    public int ReceteId { get; set; }

    public int? MuayeneId { get; set; }

    public int? HastaId { get; set; }

    public int? DoktorId { get; set; }

    public DateTime? ReceteTarihi { get; set; }

    public int? GecerlilikSuresi { get; set; }

    public string? Durum { get; set; }

    public virtual Doktor? Doktor { get; set; }

    public virtual Hastum? Hasta { get; set; }

    public virtual Muayene? Muayene { get; set; }

    public virtual ICollection<ReceteDetay> ReceteDetays { get; set; } = new List<ReceteDetay>();
}
