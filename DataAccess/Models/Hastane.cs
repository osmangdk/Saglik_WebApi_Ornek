using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Hastane
{
    public int HastaneId { get; set; }

    public string HastaneAdi { get; set; } = null!;

    public string? Adres { get; set; }

    public string? Telefon { get; set; }

    public string? Email { get; set; }

    public DateOnly? KurulusTarihi { get; set; }

    public int? YatakKapasitesi { get; set; }

    public bool? Aktif { get; set; }

    public DateTime? OlusturmaTarihi { get; set; }

    public virtual ICollection<Bolum> Bolums { get; set; } = new List<Bolum>();

    public virtual ICollection<Doktor> Doktors { get; set; } = new List<Doktor>();

    public virtual ICollection<YatakliServi> YatakliServis { get; set; } = new List<YatakliServi>();
}
