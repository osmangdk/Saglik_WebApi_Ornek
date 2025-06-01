using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Hastum
{
    public int HastaId { get; set; }

    public string TcNo { get; set; } = null!;

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public DateOnly? DogumTarihi { get; set; }

    public char? Cinsiyet { get; set; }

    public string? Telefon { get; set; }

    public string? Email { get; set; }

    public string? Adres { get; set; }

    public string? KanGrubu { get; set; }

    public string? SigortaNo { get; set; }

    public string? AcilDurumdaAranacakKisi { get; set; }

    public string? AcilTelefon { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public bool? Aktif { get; set; }

    public virtual ICollection<Muayene> Muayenes { get; set; } = new List<Muayene>();

    public virtual ICollection<Randevu> Randevus { get; set; } = new List<Randevu>();

    public virtual ICollection<Recete> Recetes { get; set; } = new List<Recete>();

    public virtual ICollection<TetkikTalep> TetkikTaleps { get; set; } = new List<TetkikTalep>();

    public virtual ICollection<Yati> Yatis { get; set; } = new List<Yati>();
}
