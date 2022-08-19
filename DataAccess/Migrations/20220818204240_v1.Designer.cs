﻿// <auto-generated />
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(KonusarakOgrenContext))]
    [Migration("20220818204240_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Entities.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("DataAccess.Entities.KullaniciDetayi", b =>
                {
                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cinsiyet")
                        .HasColumnType("int");

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SehirId")
                        .HasColumnType("int");

                    b.Property<int>("UlkeId")
                        .HasColumnType("int");

                    b.HasKey("KullaniciId");

                    b.HasIndex("SehirId");

                    b.HasIndex("UlkeId");

                    b.ToTable("KullaniciDetaylari");
                });

            modelBuilder.Entity("DataAccess.Entities.Marka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Markalar");
                });

            modelBuilder.Entity("DataAccess.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roller");
                });

            modelBuilder.Entity("DataAccess.Entities.Sehir", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UlkeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UlkeId");

                    b.ToTable("Sehirler");
                });

            modelBuilder.Entity("DataAccess.Entities.Ulke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Ulkeler");
                });

            modelBuilder.Entity("DataAccess.Entities.Urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Aciklamasi")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Boyut")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MarkaId")
                        .HasColumnType("int");

                    b.Property<string>("Renk")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("MarkaId");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("DataAccess.Entities.Kullanici", b =>
                {
                    b.HasOne("DataAccess.Entities.Rol", "Rol")
                        .WithMany("Kullanicilar")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("DataAccess.Entities.KullaniciDetayi", b =>
                {
                    b.HasOne("DataAccess.Entities.Kullanici", "Kullanici")
                        .WithOne("KullaniciDetayi")
                        .HasForeignKey("DataAccess.Entities.KullaniciDetayi", "KullaniciId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Sehir", "Sehir")
                        .WithMany("KullaniciDetaylari")
                        .HasForeignKey("SehirId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Ulke", "Ulke")
                        .WithMany("KullaniciDetaylari")
                        .HasForeignKey("UlkeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Kullanici");

                    b.Navigation("Sehir");

                    b.Navigation("Ulke");
                });

            modelBuilder.Entity("DataAccess.Entities.Sehir", b =>
                {
                    b.HasOne("DataAccess.Entities.Ulke", "Ulke")
                        .WithMany("Sehirler")
                        .HasForeignKey("UlkeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ulke");
                });

            modelBuilder.Entity("DataAccess.Entities.Urun", b =>
                {
                    b.HasOne("DataAccess.Entities.Marka", "Marka")
                        .WithMany("Urunler")
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Marka");
                });

            modelBuilder.Entity("DataAccess.Entities.Kullanici", b =>
                {
                    b.Navigation("KullaniciDetayi");
                });

            modelBuilder.Entity("DataAccess.Entities.Marka", b =>
                {
                    b.Navigation("Urunler");
                });

            modelBuilder.Entity("DataAccess.Entities.Rol", b =>
                {
                    b.Navigation("Kullanicilar");
                });

            modelBuilder.Entity("DataAccess.Entities.Sehir", b =>
                {
                    b.Navigation("KullaniciDetaylari");
                });

            modelBuilder.Entity("DataAccess.Entities.Ulke", b =>
                {
                    b.Navigation("KullaniciDetaylari");

                    b.Navigation("Sehirler");
                });
#pragma warning restore 612, 618
        }
    }
}
