using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public partial class HastaneContext : DbContext, IDisposable
{
    private readonly IConfiguration _configuration;
    public HastaneContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConn"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgagent", "pgagent");

        modelBuilder.Entity<Bolum>(entity =>
        {
            entity.HasKey(e => e.BolumId).HasName("bolum_pkey");

            entity.ToTable("bolum");

            entity.Property(e => e.BolumId).HasColumnName("bolum_id");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.Aktif)
                .HasDefaultValue(true)
                .HasColumnName("aktif");
            entity.Property(e => e.BolumAdi)
                .HasMaxLength(100)
                .HasColumnName("bolum_adi");
            entity.Property(e => e.HastaneId).HasColumnName("hastane_id");
            entity.Property(e => e.OlusturmaTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("olusturma_tarihi");

            entity.HasOne(d => d.Hastane).WithMany(p => p.Bolums)
                .HasForeignKey(d => d.HastaneId)
                .HasConstraintName("bolum_hastane_id_fkey");
        });

        modelBuilder.Entity<Doktor>(entity =>
        {
            entity.HasKey(e => e.DoktorId).HasName("doktor_pkey");

            entity.ToTable("doktor");

            entity.HasIndex(e => e.TcNo, "doktor_tc_no_key").IsUnique();

            entity.HasIndex(e => e.TcNo, "idx_doktor_tc");

            entity.Property(e => e.DoktorId).HasColumnName("doktor_id");
            entity.Property(e => e.Ad)
                .HasMaxLength(250)
                .HasColumnName("ad");
            entity.Property(e => e.Aktif)
                .HasDefaultValue(true)
                .HasColumnName("aktif");
            entity.Property(e => e.BolumId).HasColumnName("bolum_id");
            entity.Property(e => e.DiplomaNo)
                .HasMaxLength(10)
                .HasColumnName("diploma_no");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HastaneId).HasColumnName("hastane_id");
            entity.Property(e => e.IseBaslamaTarihi).HasColumnName("ise_baslama_tarihi");
            entity.Property(e => e.OlusturmaTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("olusturma_tarihi");
            entity.Property(e => e.Soyad)
                .HasMaxLength(50)
                .HasColumnName("soyad");
            entity.Property(e => e.TcNo)
                .HasMaxLength(11)
                .HasColumnName("tc_no");
            entity.Property(e => e.Telefon)
                .HasMaxLength(15)
                .HasColumnName("telefon");
            entity.Property(e => e.UzmanlikAlani)
                .HasMaxLength(100)
                .HasColumnName("uzmanlik_alani");

            entity.HasOne(d => d.Bolum).WithMany(p => p.Doktors)
                .HasForeignKey(d => d.BolumId)
                .HasConstraintName("doktor_bolum_id_fkey");

            entity.HasOne(d => d.Hastane).WithMany(p => p.Doktors)
                .HasForeignKey(d => d.HastaneId)
                .HasConstraintName("doktor_hastane_id_fkey");
        });

        modelBuilder.Entity<Hastane>(entity =>
        {
            entity.HasKey(e => e.HastaneId).HasName("hastane_pkey");

            entity.ToTable("hastane");

            entity.Property(e => e.HastaneId).HasColumnName("hastane_id");
            entity.Property(e => e.Adres).HasColumnName("adres");
            entity.Property(e => e.Aktif)
                .HasDefaultValue(true)
                .HasColumnName("aktif");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.HastaneAdi)
                .HasMaxLength(100)
                .HasColumnName("hastane_adi");
            entity.Property(e => e.KurulusTarihi).HasColumnName("kurulus_tarihi");
            entity.Property(e => e.OlusturmaTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("olusturma_tarihi");
            entity.Property(e => e.Telefon)
                .HasMaxLength(15)
                .HasColumnName("telefon");
            entity.Property(e => e.YatakKapasitesi).HasColumnName("yatak_kapasitesi");
        });

        modelBuilder.Entity<Hastum>(entity =>
        {
            entity.HasKey(e => e.HastaId).HasName("hasta_pkey");

            entity.ToTable("hasta");

            entity.HasIndex(e => e.TcNo, "hasta_tc_no_key").IsUnique();

            entity.HasIndex(e => e.TcNo, "idx_hasta_tc");

            entity.Property(e => e.HastaId).HasColumnName("hasta_id");
            entity.Property(e => e.AcilDurumdaAranacakKisi)
                .HasMaxLength(100)
                .HasColumnName("acil_durumda_aranacak_kisi");
            entity.Property(e => e.AcilTelefon)
                .HasMaxLength(15)
                .HasColumnName("acil_telefon");
            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .HasColumnName("ad");
            entity.Property(e => e.Adres).HasColumnName("adres");
            entity.Property(e => e.Aktif)
                .HasDefaultValue(true)
                .HasColumnName("aktif");
            entity.Property(e => e.Cinsiyet)
                .HasMaxLength(1)
                .HasColumnName("cinsiyet");
            entity.Property(e => e.DogumTarihi).HasColumnName("dogum_tarihi");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.KanGrubu)
                .HasMaxLength(5)
                .HasColumnName("kan_grubu");
            entity.Property(e => e.KayitTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("kayit_tarihi");
            entity.Property(e => e.SigortaNo)
                .HasMaxLength(50)
                .HasColumnName("sigorta_no");
            entity.Property(e => e.Soyad)
                .HasMaxLength(50)
                .HasColumnName("soyad");
            entity.Property(e => e.TcNo)
                .HasMaxLength(11)
                .HasColumnName("tc_no");
            entity.Property(e => e.Telefon)
                .HasMaxLength(15)
                .HasColumnName("telefon");
        });

        modelBuilder.Entity<Ilac>(entity =>
        {
            entity.HasKey(e => e.IlacId).HasName("ilac_pkey");

            entity.ToTable("ilac");

            entity.Property(e => e.IlacId).HasColumnName("ilac_id");
            entity.Property(e => e.Aktif)
                .HasDefaultValue(true)
                .HasColumnName("aktif");
            entity.Property(e => e.Doz)
                .HasMaxLength(50)
                .HasColumnName("doz");
            entity.Property(e => e.EtkenMadde)
                .HasMaxLength(100)
                .HasColumnName("etken_madde");
            entity.Property(e => e.Form)
                .HasMaxLength(50)
                .HasColumnName("form");
            entity.Property(e => e.IlacAdi)
                .HasMaxLength(100)
                .HasColumnName("ilac_adi");
            entity.Property(e => e.OlusturmaTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("olusturma_tarihi");
            entity.Property(e => e.UreticiFirma)
                .HasMaxLength(100)
                .HasColumnName("uretici_firma");
        });

        modelBuilder.Entity<Muayene>(entity =>
        {
            entity.HasKey(e => e.MuayeneId).HasName("muayene_pkey");

            entity.ToTable("muayene");

            entity.HasIndex(e => e.MuayeneTarihi, "idx_muayene_tarih");

            entity.Property(e => e.MuayeneId).HasColumnName("muayene_id");
            entity.Property(e => e.DoktorId).HasColumnName("doktor_id");
            entity.Property(e => e.Durum)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Devam Ediyor'::character varying")
                .HasColumnName("durum");
            entity.Property(e => e.HastaId).HasColumnName("hasta_id");
            entity.Property(e => e.MuayeneTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("muayene_tarihi");
            entity.Property(e => e.NotBilgisi).HasColumnName("not_bilgisi");
            entity.Property(e => e.RandevuId).HasColumnName("randevu_id");
            entity.Property(e => e.Sikayet).HasColumnName("sikayet");
            entity.Property(e => e.Tani).HasColumnName("tani");
            entity.Property(e => e.TedaviPlani).HasColumnName("tedavi_plani");

            entity.HasOne(d => d.Doktor).WithMany(p => p.Muayenes)
                .HasForeignKey(d => d.DoktorId)
                .HasConstraintName("muayene_doktor_id_fkey");

            entity.HasOne(d => d.Hasta).WithMany(p => p.Muayenes)
                .HasForeignKey(d => d.HastaId)
                .HasConstraintName("muayene_hasta_id_fkey");

            entity.HasOne(d => d.Randevu).WithMany(p => p.Muayenes)
                .HasForeignKey(d => d.RandevuId)
                .HasConstraintName("muayene_randevu_id_fkey");
        });

        modelBuilder.Entity<Randevu>(entity =>
        {
            entity.HasKey(e => e.RandevuId).HasName("randevu_pkey");

            entity.ToTable("randevu");

            entity.HasIndex(e => e.RandevuTarihi, "idx_randevu_tarih");

            entity.Property(e => e.RandevuId).HasColumnName("randevu_id");
            entity.Property(e => e.DoktorId).HasColumnName("doktor_id");
            entity.Property(e => e.Durum)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Bekliyor'::character varying")
                .HasColumnName("durum");
            entity.Property(e => e.HastaId).HasColumnName("hasta_id");
            entity.Property(e => e.NotBilgisi).HasColumnName("not_bilgisi");
            entity.Property(e => e.OlusturmaTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("olusturma_tarihi");
            entity.Property(e => e.RandevuSuresi)
                .HasDefaultValue(30)
                .HasColumnName("randevu_suresi");
            entity.Property(e => e.RandevuTarihi)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("randevu_tarihi");

            entity.HasOne(d => d.Doktor).WithMany(p => p.Randevus)
                .HasForeignKey(d => d.DoktorId)
                .HasConstraintName("randevu_doktor_id_fkey");

            entity.HasOne(d => d.Hasta).WithMany(p => p.Randevus)
                .HasForeignKey(d => d.HastaId)
                .HasConstraintName("randevu_hasta_id_fkey");
        });

        modelBuilder.Entity<Recete>(entity =>
        {
            entity.HasKey(e => e.ReceteId).HasName("recete_pkey");

            entity.ToTable("recete");

            entity.Property(e => e.ReceteId).HasColumnName("recete_id");
            entity.Property(e => e.DoktorId).HasColumnName("doktor_id");
            entity.Property(e => e.Durum)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Aktif'::character varying")
                .HasColumnName("durum");
            entity.Property(e => e.GecerlilikSuresi)
                .HasDefaultValue(30)
                .HasColumnName("gecerlilik_suresi");
            entity.Property(e => e.HastaId).HasColumnName("hasta_id");
            entity.Property(e => e.MuayeneId).HasColumnName("muayene_id");
            entity.Property(e => e.ReceteTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("recete_tarihi");

            entity.HasOne(d => d.Doktor).WithMany(p => p.Recetes)
                .HasForeignKey(d => d.DoktorId)
                .HasConstraintName("recete_doktor_id_fkey");

            entity.HasOne(d => d.Hasta).WithMany(p => p.Recetes)
                .HasForeignKey(d => d.HastaId)
                .HasConstraintName("recete_hasta_id_fkey");

            entity.HasOne(d => d.Muayene).WithMany(p => p.Recetes)
                .HasForeignKey(d => d.MuayeneId)
                .HasConstraintName("recete_muayene_id_fkey");
        });

        modelBuilder.Entity<ReceteDetay>(entity =>
        {
            entity.HasKey(e => e.DetayId).HasName("recete_detay_pkey");

            entity.ToTable("recete_detay");

            entity.Property(e => e.DetayId).HasColumnName("detay_id");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.GunSayisi).HasColumnName("gun_sayisi");
            entity.Property(e => e.IlacId).HasColumnName("ilac_id");
            entity.Property(e => e.KullanimSekli).HasColumnName("kullanim_sekli");
            entity.Property(e => e.Miktar).HasColumnName("miktar");
            entity.Property(e => e.ReceteId).HasColumnName("recete_id");

            entity.HasOne(d => d.Ilac).WithMany(p => p.ReceteDetays)
                .HasForeignKey(d => d.IlacId)
                .HasConstraintName("recete_detay_ilac_id_fkey");

            entity.HasOne(d => d.Recete).WithMany(p => p.ReceteDetays)
                .HasForeignKey(d => d.ReceteId)
                .HasConstraintName("recete_detay_recete_id_fkey");
        });

        modelBuilder.Entity<Tetkik>(entity =>
        {
            entity.HasKey(e => e.TetkikId).HasName("tetkik_pkey");

            entity.ToTable("tetkik");

            entity.HasIndex(e => e.TetkikKodu, "tetkik_tetkik_kodu_key").IsUnique();

            entity.Property(e => e.TetkikId).HasColumnName("tetkik_id");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.Aktif)
                .HasDefaultValue(true)
                .HasColumnName("aktif");
            entity.Property(e => e.Birim)
                .HasMaxLength(20)
                .HasColumnName("birim");
            entity.Property(e => e.NormalDegerMax)
                .HasPrecision(10, 2)
                .HasColumnName("normal_deger_max");
            entity.Property(e => e.NormalDegerMin)
                .HasPrecision(10, 2)
                .HasColumnName("normal_deger_min");
            entity.Property(e => e.OlusturmaTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("olusturma_tarihi");
            entity.Property(e => e.TetkikAdi)
                .HasMaxLength(100)
                .HasColumnName("tetkik_adi");
            entity.Property(e => e.TetkikKodu)
                .HasMaxLength(20)
                .HasColumnName("tetkik_kodu");
        });

        modelBuilder.Entity<TetkikSonuc>(entity =>
        {
            entity.HasKey(e => e.SonucId).HasName("tetkik_sonuc_pkey");

            entity.ToTable("tetkik_sonuc");

            entity.HasIndex(e => e.SonucTarihi, "idx_tetkik_sonuc_tarih");

            entity.Property(e => e.SonucId).HasColumnName("sonuc_id");
            entity.Property(e => e.Durum)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Normal'::character varying")
                .HasColumnName("durum");
            entity.Property(e => e.OnaylayanDoktor).HasColumnName("onaylayan_doktor");
            entity.Property(e => e.RaporEdenPersonel).HasColumnName("rapor_eden_personel");
            entity.Property(e => e.SonucDegeri)
                .HasPrecision(10, 2)
                .HasColumnName("sonuc_degeri");
            entity.Property(e => e.SonucMetni).HasColumnName("sonuc_metni");
            entity.Property(e => e.SonucTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sonuc_tarihi");
            entity.Property(e => e.TalepId).HasColumnName("talep_id");

            entity.HasOne(d => d.OnaylayanDoktorNavigation).WithMany(p => p.TetkikSonucs)
                .HasForeignKey(d => d.OnaylayanDoktor)
                .HasConstraintName("tetkik_sonuc_onaylayan_doktor_fkey");

            entity.HasOne(d => d.Talep).WithMany(p => p.TetkikSonucs)
                .HasForeignKey(d => d.TalepId)
                .HasConstraintName("tetkik_sonuc_talep_id_fkey");
        });

        modelBuilder.Entity<TetkikTalep>(entity =>
        {
            entity.HasKey(e => e.TalepId).HasName("tetkik_talep_pkey");

            entity.ToTable("tetkik_talep");

            entity.Property(e => e.TalepId).HasColumnName("talep_id");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.DoktorId).HasColumnName("doktor_id");
            entity.Property(e => e.Durum)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Bekliyor'::character varying")
                .HasColumnName("durum");
            entity.Property(e => e.HastaId).HasColumnName("hasta_id");
            entity.Property(e => e.MuayeneId).HasColumnName("muayene_id");
            entity.Property(e => e.TalepTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("talep_tarihi");
            entity.Property(e => e.TetkikId).HasColumnName("tetkik_id");

            entity.HasOne(d => d.Doktor).WithMany(p => p.TetkikTaleps)
                .HasForeignKey(d => d.DoktorId)
                .HasConstraintName("tetkik_talep_doktor_id_fkey");

            entity.HasOne(d => d.Hasta).WithMany(p => p.TetkikTaleps)
                .HasForeignKey(d => d.HastaId)
                .HasConstraintName("tetkik_talep_hasta_id_fkey");

            entity.HasOne(d => d.Muayene).WithMany(p => p.TetkikTaleps)
                .HasForeignKey(d => d.MuayeneId)
                .HasConstraintName("tetkik_talep_muayene_id_fkey");

            entity.HasOne(d => d.Tetkik).WithMany(p => p.TetkikTaleps)
                .HasForeignKey(d => d.TetkikId)
                .HasConstraintName("tetkik_talep_tetkik_id_fkey");
        });

        modelBuilder.Entity<VAktifYatislar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_aktif_yatislar");

            entity.Property(e => e.DoktorAdi).HasColumnName("doktor_adi");
            entity.Property(e => e.HastaAdi).HasColumnName("hasta_adi");
            entity.Property(e => e.ServisAdi)
                .HasMaxLength(50)
                .HasColumnName("servis_adi");
            entity.Property(e => e.TahminiCikisTarihi).HasColumnName("tahmini_cikis_tarihi");
            entity.Property(e => e.YatakNo)
                .HasMaxLength(10)
                .HasColumnName("yatak_no");
            entity.Property(e => e.YatisNedeni).HasColumnName("yatis_nedeni");
            entity.Property(e => e.YatisTarihi)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("yatis_tarihi");
        });

        modelBuilder.Entity<VHastaRandevu>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_hasta_randevu");

            entity.Property(e => e.BolumAdi)
                .HasMaxLength(50)
                .HasColumnName("bolum_adi");
            entity.Property(e => e.DoktorAdi).HasColumnName("doktor_adi");
            entity.Property(e => e.Durum)
                .HasMaxLength(20)
                .HasColumnName("durum");
            entity.Property(e => e.HastaAdi).HasColumnName("hasta_adi");
            entity.Property(e => e.NotBilgisi).HasColumnName("not_bilgisi");
            entity.Property(e => e.RandevuTarihi)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("randevu_tarihi");
        });

        modelBuilder.Entity<Yatak>(entity =>
        {
            entity.HasKey(e => e.YatakId).HasName("yatak_pkey");

            entity.ToTable("yatak");

            entity.Property(e => e.YatakId).HasColumnName("yatak_id");
            entity.Property(e => e.Aktif)
                .HasDefaultValue(true)
                .HasColumnName("aktif");
            entity.Property(e => e.Durum)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Bos'::character varying")
                .HasColumnName("durum");
            entity.Property(e => e.OdaNo)
                .HasMaxLength(10)
                .HasColumnName("oda_no");
            entity.Property(e => e.ServisId).HasColumnName("servis_id");
            entity.Property(e => e.YatakNo)
                .HasMaxLength(10)
                .HasColumnName("yatak_no");
            entity.Property(e => e.YatakTipi)
                .HasMaxLength(20)
                .HasColumnName("yatak_tipi");

            entity.HasOne(d => d.Servis).WithMany(p => p.Yataks)
                .HasForeignKey(d => d.ServisId)
                .HasConstraintName("yatak_servis_id_fkey");
        });

        modelBuilder.Entity<YatakliServi>(entity =>
        {
            entity.HasKey(e => e.ServisId).HasName("yatakli_servis_pkey");

            entity.ToTable("yatakli_servis");

            entity.Property(e => e.ServisId).HasColumnName("servis_id");
            entity.Property(e => e.Aktif)
                .HasDefaultValue(true)
                .HasColumnName("aktif");
            entity.Property(e => e.BolumId).HasColumnName("bolum_id");
            entity.Property(e => e.HastaneId).HasColumnName("hastane_id");
            entity.Property(e => e.ServisAdi)
                .HasMaxLength(50)
                .HasColumnName("servis_adi");
            entity.Property(e => e.YatakSayisi).HasColumnName("yatak_sayisi");

            entity.HasOne(d => d.Bolum).WithMany(p => p.YatakliServis)
                .HasForeignKey(d => d.BolumId)
                .HasConstraintName("yatakli_servis_bolum_id_fkey");

            entity.HasOne(d => d.Hastane).WithMany(p => p.YatakliServis)
                .HasForeignKey(d => d.HastaneId)
                .HasConstraintName("yatakli_servis_hastane_id_fkey");
        });

        modelBuilder.Entity<Yati>(entity =>
        {
            entity.HasKey(e => e.YatisId).HasName("yatis_pkey");

            entity.ToTable("yatis");

            entity.Property(e => e.YatisId).HasColumnName("yatis_id");
            entity.Property(e => e.CikisTarihi)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("cikis_tarihi");
            entity.Property(e => e.Durum)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Yatiliyor'::character varying")
                .HasColumnName("durum");
            entity.Property(e => e.HastaId).HasColumnName("hasta_id");
            entity.Property(e => e.SorumluDoktor).HasColumnName("sorumlu_doktor");
            entity.Property(e => e.TahminiCikisTarihi).HasColumnName("tahmini_cikis_tarihi");
            entity.Property(e => e.YatakId).HasColumnName("yatak_id");
            entity.Property(e => e.YatisNedeni).HasColumnName("yatis_nedeni");
            entity.Property(e => e.YatisTarihi)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("yatis_tarihi");

            entity.HasOne(d => d.Hasta).WithMany(p => p.Yatis)
                .HasForeignKey(d => d.HastaId)
                .HasConstraintName("yatis_hasta_id_fkey");

            entity.HasOne(d => d.SorumluDoktorNavigation).WithMany(p => p.Yatis)
                .HasForeignKey(d => d.SorumluDoktor)
                .HasConstraintName("yatis_sorumlu_doktor_fkey");

            entity.HasOne(d => d.Yatak).WithMany(p => p.Yatis)
                .HasForeignKey(d => d.YatakId)
                .HasConstraintName("yatis_yatak_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public virtual DbSet<Bolum> Bolums { get; set; }

    public virtual DbSet<Doktor> Doktors { get; set; }

    public virtual DbSet<Hastane> Hastanes { get; set; }

    public virtual DbSet<Hastum> Hasta { get; set; }

    public virtual DbSet<Ilac> Ilacs { get; set; }

    public virtual DbSet<Muayene> Muayenes { get; set; }

    public virtual DbSet<Randevu> Randevus { get; set; }

    public virtual DbSet<Recete> Recetes { get; set; }

    public virtual DbSet<ReceteDetay> ReceteDetays { get; set; }

    public virtual DbSet<Tetkik> Tetkiks { get; set; }

    public virtual DbSet<TetkikSonuc> TetkikSonucs { get; set; }

    public virtual DbSet<TetkikTalep> TetkikTaleps { get; set; }

    public virtual DbSet<VAktifYatislar> VAktifYatislars { get; set; }

    public virtual DbSet<VHastaRandevu> VHastaRandevus { get; set; }

    public virtual DbSet<Yatak> Yataks { get; set; }

    public virtual DbSet<YatakliServi> YatakliServis { get; set; }

    public virtual DbSet<Yati> Yatis { get; set; }

   
}
