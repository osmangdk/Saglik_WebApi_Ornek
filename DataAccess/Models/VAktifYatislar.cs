using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class VAktifYatislar
{
    public string? HastaAdi { get; set; }

    public string? DoktorAdi { get; set; }

    public string? ServisAdi { get; set; }

    public string? YatakNo { get; set; }

    public DateTime? YatisTarihi { get; set; }

    public DateOnly? TahminiCikisTarihi { get; set; }

    public string? YatisNedeni { get; set; }
}
