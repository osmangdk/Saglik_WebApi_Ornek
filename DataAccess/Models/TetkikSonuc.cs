using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class TetkikSonuc
{
    public int SonucId { get; set; }

    public int? TalepId { get; set; }

    public decimal? SonucDegeri { get; set; }

    public string? SonucMetni { get; set; }

    public DateTime? SonucTarihi { get; set; }

    public int? RaporEdenPersonel { get; set; }

    public int? OnaylayanDoktor { get; set; }

    public string? Durum { get; set; }

    public virtual Doktor? OnaylayanDoktorNavigation { get; set; }

    public virtual TetkikTalep? Talep { get; set; }
}
