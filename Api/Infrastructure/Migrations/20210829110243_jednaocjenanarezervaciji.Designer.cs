﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportskiCentarRS2.Infrastructure.Persistence;

namespace SportskiCentarRS2.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210829110243_jednaocjenanarezervaciji")]
    partial class jednaocjenanarezervaciji
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.KorisnickaUloga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Notifikacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Poruka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PosiljalacId")
                        .HasColumnType("int");

                    b.Property<int>("PrimalacId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PosiljalacId");

                    b.HasIndex("PrimalacId");

                    b.ToTable("Notifikacije");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Ocjena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("RezervacijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("RezervacijaId")
                        .IsUnique();

                    b.ToTable("Ocjene");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Oprema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("IzmijenjenoDatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("KreiranoDatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<int>("KreoiraoKorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZadnjiIzmijenioKorisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KreoiraoKorisnikId");

                    b.HasIndex("ZadnjiIzmijenioKorisnikId");

                    b.ToTable("Oprema");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Prostorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("IzmijenjenoDatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("KreiranoDatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<int>("KreoiraoKorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Velicina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZadnjiIzmijenioKorisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KreoiraoKorisnikId");

                    b.HasIndex("ZadnjiIzmijenioKorisnikId");

                    b.ToTable("Prostorije");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.ProstorijaOprema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OpremaId")
                        .HasColumnType("int");

                    b.Property<int>("ProstorijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OpremaId");

                    b.HasIndex("ProstorijaId");

                    b.ToTable("ProstoroijeOpreme");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRezervacije")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IzmijenjenoDatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<DateTime>("KreiranoDatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<int>("KreoiraoKorisnikId")
                        .HasColumnType("int");

                    b.Property<bool>("Odobrena")
                        .HasColumnType("bit");

                    b.Property<int>("TerminId")
                        .HasColumnType("int");

                    b.Property<int?>("ZadnjiIzmijenioKorisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("KreoiraoKorisnikId");

                    b.HasIndex("TerminId");

                    b.HasIndex("ZadnjiIzmijenioKorisnikId");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Termin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("IzmijenjenoDatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Kraj")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("KreiranoDatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<int>("KreoiraoKorisnikId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Pocetak")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProstorijaId")
                        .HasColumnType("int");

                    b.Property<bool>("Slobodan")
                        .HasColumnType("bit");

                    b.Property<int?>("ZadnjiIzmijenioKorisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KreoiraoKorisnikId");

                    b.HasIndex("ProstorijaId");

                    b.HasIndex("ZadnjiIzmijenioKorisnikId");

                    b.ToTable("Termini");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Uplata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumUplate")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("RezervacijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("RezervacijaId");

                    b.ToTable("Uplate");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.KorisnickaUloga", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.KorisnickaUloga", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Korisnik", b =>
                {
                    b.OwnsOne("SportskiCentarRS2.Domain.ValueObjects.JMBG", "JMBG", b1 =>
                        {
                            b1.Property<int>("KorisnikId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("KorisnikId");

                            b1.ToTable("AspNetUsers");

                            b1.WithOwner()
                                .HasForeignKey("KorisnikId");
                        });

                    b.Navigation("JMBG");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Notifikacija", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "Posiljalac")
                        .WithMany()
                        .HasForeignKey("PosiljalacId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "Primalac")
                        .WithMany()
                        .HasForeignKey("PrimalacId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Posiljalac");

                    b.Navigation("Primalac");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Ocjena", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Rezervacija", "Rezervacija")
                        .WithOne("Ocjena")
                        .HasForeignKey("SportskiCentarRS2.Domain.Entities.Ocjena", "RezervacijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SportskiCentarRS2.Domain.ValueObjects.VrijednostOcjene", "Vrijednost", b1 =>
                        {
                            b1.Property<int>("OcjenaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("OcjenaId");

                            b1.ToTable("Ocjene");

                            b1.WithOwner()
                                .HasForeignKey("OcjenaId");
                        });

                    b.Navigation("Korisnik");

                    b.Navigation("Rezervacija");

                    b.Navigation("Vrijednost");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Oprema", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "KreoiraoKorisnik")
                        .WithMany()
                        .HasForeignKey("KreoiraoKorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "ZadnjiIzmijenioKorisnik")
                        .WithMany()
                        .HasForeignKey("ZadnjiIzmijenioKorisnikId");

                    b.OwnsOne("SportskiCentarRS2.Domain.ValueObjects.Kolicina", "NaStanju", b1 =>
                        {
                            b1.Property<int>("OpremaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("OpremaId");

                            b1.ToTable("Oprema");

                            b1.WithOwner()
                                .HasForeignKey("OpremaId");
                        });

                    b.Navigation("KreoiraoKorisnik");

                    b.Navigation("NaStanju");

                    b.Navigation("ZadnjiIzmijenioKorisnik");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Prostorija", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "KreoiraoKorisnik")
                        .WithMany()
                        .HasForeignKey("KreoiraoKorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "ZadnjiIzmijenioKorisnik")
                        .WithMany()
                        .HasForeignKey("ZadnjiIzmijenioKorisnikId");

                    b.Navigation("KreoiraoKorisnik");

                    b.Navigation("ZadnjiIzmijenioKorisnik");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.ProstorijaOprema", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.Oprema", "Oprema")
                        .WithMany()
                        .HasForeignKey("OpremaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Prostorija", "Prostorija")
                        .WithMany()
                        .HasForeignKey("ProstorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SportskiCentarRS2.Domain.ValueObjects.Kolicina", "Kolicina", b1 =>
                        {
                            b1.Property<int>("ProstorijaOpremaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("ProstorijaOpremaId");

                            b1.ToTable("ProstoroijeOpreme");

                            b1.WithOwner()
                                .HasForeignKey("ProstorijaOpremaId");
                        });

                    b.Navigation("Kolicina");

                    b.Navigation("Oprema");

                    b.Navigation("Prostorija");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Rezervacija", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "KreoiraoKorisnik")
                        .WithMany()
                        .HasForeignKey("KreoiraoKorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Termin", "Termin")
                        .WithMany()
                        .HasForeignKey("TerminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "ZadnjiIzmijenioKorisnik")
                        .WithMany()
                        .HasForeignKey("ZadnjiIzmijenioKorisnikId");

                    b.Navigation("Korisnik");

                    b.Navigation("KreoiraoKorisnik");

                    b.Navigation("Termin");

                    b.Navigation("ZadnjiIzmijenioKorisnik");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Termin", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "KreoiraoKorisnik")
                        .WithMany()
                        .HasForeignKey("KreoiraoKorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Prostorija", "Prostorija")
                        .WithMany()
                        .HasForeignKey("ProstorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "ZadnjiIzmijenioKorisnik")
                        .WithMany()
                        .HasForeignKey("ZadnjiIzmijenioKorisnikId");

                    b.OwnsOne("SportskiCentarRS2.Domain.ValueObjects.Cijena", "Cijena", b1 =>
                        {
                            b1.Property<int>("TerminId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("TerminId");

                            b1.ToTable("Termini");

                            b1.WithOwner()
                                .HasForeignKey("TerminId");
                        });

                    b.Navigation("Cijena");

                    b.Navigation("KreoiraoKorisnik");

                    b.Navigation("Prostorija");

                    b.Navigation("ZadnjiIzmijenioKorisnik");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Uplata", b =>
                {
                    b.HasOne("SportskiCentarRS2.Domain.Entities.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportskiCentarRS2.Domain.Entities.Rezervacija", "Rezervacija")
                        .WithMany()
                        .HasForeignKey("RezervacijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Rezervacija");
                });

            modelBuilder.Entity("SportskiCentarRS2.Domain.Entities.Rezervacija", b =>
                {
                    b.Navigation("Ocjena");
                });
#pragma warning restore 612, 618
        }
    }
}