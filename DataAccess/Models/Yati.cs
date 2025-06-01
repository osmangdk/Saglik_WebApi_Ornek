using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Yati
{
    public int YatisId { get; set; }

    public int? HastaId { get; set; }

    public int? YatakId { get; set; }

    public int? SorumluDoktor { get; set; }

    public DateTime? YatisTarihi { get; set; }

    public DateOnly? TahminiCikisTarihi { get; set; }

    public DateTime? CikisTarihi { get; set; }

    public string? YatisNedeni { get; set; }

    public string? Durum { get; set; }

    public virtual Hastum? Hasta { get; set; }

    public virtual Doktor? SorumluDoktorNavigation { get; set; }

    public virtual Yatak? Yatak { get; set; }
}
