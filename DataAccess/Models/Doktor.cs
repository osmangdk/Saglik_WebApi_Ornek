using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public partial class Doktor
{
    public int DoktorId { get; set; }

    public int? HastaneId { get; set; }

    public int? BolumId { get; set; }

    public string TcNo { get; set; } = null!;

    [Required(ErrorMessage ="{0} alan adı boş geçilemez.")]
    [StringLength(100,ErrorMessage ="{0} en fazla {1} karakteri geçemez!")]
    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string? Telefon { get; set; }

    public string? Email { get; set; }

    public string? UzmanlikAlani { get; set; }

    public string? DiplomaNo { get; set; }

    public DateOnly? IseBaslamaTarihi { get; set; }

    public bool? Aktif { get; set; }

    public DateTime? OlusturmaTarihi { get; set; }

    public virtual Bolum? Bolum { get; set; }

    public virtual Hastane? Hastane { get; set; }

    public virtual ICollection<Muayene> Muayenes { get; set; } = new List<Muayene>();

    public virtual ICollection<Randevu> Randevus { get; set; } = new List<Randevu>();

    public virtual ICollection<Recete> Recetes { get; set; } = new List<Recete>();

    public virtual ICollection<TetkikSonuc> TetkikSonucs { get; set; } = new List<TetkikSonuc>();

    public virtual ICollection<TetkikTalep> TetkikTaleps { get; set; } = new List<TetkikTalep>();

    public virtual ICollection<Yati> Yatis { get; set; } = new List<Yati>();
}
