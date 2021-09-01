using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Rezervacije.Commands.CreateRezervaciju;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUsersAsync(UserManager<Korisnik> userManager, RoleManager<KorisnickaUloga> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new KorisnickaUloga("Admin"));
                await roleManager.CreateAsync(new KorisnickaUloga("Uposlenik"));
                await roleManager.CreateAsync(new KorisnickaUloga("Klijent"));
            }


            if (!userManager.Users.Any())
            {
                var administrator = new Korisnik { UserName = "administrator", Email = "administrator@sportskicentar.ba", Ime = "Administrator", Prezime = "Centra" };
                var uposlenik = new Korisnik { UserName = "uposlenik", Email = "uposlenik@sportskicentar.ba", Ime = "Uposlenik", Prezime = "Centra" };
                var klijent = new Korisnik { UserName = "klijent", Email = "klijent@sportskicentar.ba", Ime = "Klijent", Prezime = "Centra" };

                await userManager.CreateAsync(administrator, "test");
                await userManager.AddToRolesAsync(administrator, new [] { "Admin" });

                await userManager.CreateAsync(uposlenik, "test");
                await userManager.AddToRolesAsync(uposlenik, new[] { "Uposlenik" });

                await userManager.CreateAsync(klijent, "test");
                await userManager.AddToRolesAsync(klijent, new[] { "Klijent" });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context, ISender mediator)
        {
            if (!context.Prostorije.Any())
            {
                var velikaDvorana = new Prostorija
                {
                    Naziv = "Velika dvorana",
                    Velicina = "30x60"
                };
                var stonoteniskaDvorana = new Prostorija
                {
                    Naziv = "Stonoteniska dvorana",
                    Velicina = "30x30"
                };
                await context.Prostorije.AddAsync(velikaDvorana);
                await context.Prostorije.AddAsync(stonoteniskaDvorana);
                var opremaVelikeDvorane = new List<Oprema>();
                var opremaStonoteniskeDvorane = new List<Oprema>();
                opremaVelikeDvorane.Add(new Oprema { Naziv = "Fudbalska lopta", NaStanju = Kolicina.From(10) });
                opremaVelikeDvorane.Add(new Oprema { Naziv = "Košarkaška lopta", NaStanju = Kolicina.From(15) });
                opremaVelikeDvorane.Add(new Oprema { Naziv = "Rukometna lopta", NaStanju = Kolicina.From(20) });
                opremaVelikeDvorane.Add(new Oprema { Naziv = "Koš", NaStanju = Kolicina.From(4) });
                opremaVelikeDvorane.Add(new Oprema { Naziv = "Gol za fudbal/rukomet", NaStanju = Kolicina.From(2) });
                opremaVelikeDvorane.Add(new Oprema { Naziv = "Odbojkaška mreža i držači", NaStanju = Kolicina.From(2) });
                opremaStonoteniskeDvorane.Add(new Oprema { Naziv = "Stol za stolni tenis", NaStanju = Kolicina.From(5) });
                opremaStonoteniskeDvorane.Add(new Oprema { Naziv = "Stonoteniska reketa", NaStanju = Kolicina.From(20) });
                opremaStonoteniskeDvorane.Add(new Oprema { Naziv = "StonoteniskaLoptica", NaStanju = Kolicina.From(100) });

                await context.Oprema.AddRangeAsync(opremaVelikeDvorane);
                await context.Oprema.AddRangeAsync(opremaStonoteniskeDvorane);
                await context.SaveChangesAsync();
                foreach (var o in opremaVelikeDvorane)
                {
                    await context.ProstoroijeOpreme
                        .AddAsync(new ProstorijaOprema 
                        { 
                            Kolicina = Kolicina.From(o.NaStanju.Value / 2),
                            OpremaId=o.Id,
                            ProstorijaId=velikaDvorana.Id 
                        });
                }
                foreach (var o in opremaStonoteniskeDvorane)
                {
                    await context.ProstoroijeOpreme
                        .AddAsync(new ProstorijaOprema
                        {
                            Kolicina = Kolicina.From(o.NaStanju.Value / 2),
                            OpremaId = o.Id,
                            ProstorijaId = stonoteniskaDvorana.Id
                        });
                }
                await context.SaveChangesAsync();
                                
                for(int i = 0; i < 2; i++)
                {
                    var datumTermina = DateTime.Now.Date.AddDays(10).AddHours(9);                    
                    for (int j = 0; j < 12; j++)
                    {
                        await context.Termini
                            .AddAsync(new Termin
                            {
                                Cijena = Cijena.From(50),
                                Pocetak = datumTermina,
                                Kraj = datumTermina.AddHours(1),
                                ProstorijaId = i == 1 ? velikaDvorana.Id : stonoteniskaDvorana.Id,
                                Slobodan=true                              
                            });
                        datumTermina = datumTermina.AddHours(1);
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    var datumTermina = DateTime.Now.Date.AddDays(11).AddHours(9);
                    for (int j = 0; j < 12; j++)
                    {
                        await context.Termini
                            .AddAsync(new Termin
                            {
                                Cijena = Cijena.From(50),
                                Pocetak = datumTermina,
                                Kraj = datumTermina.AddHours(1),
                                ProstorijaId = i == 1 ? velikaDvorana.Id : stonoteniskaDvorana.Id,
                                Slobodan = true
                            });
                        datumTermina = datumTermina.AddHours(1);
                    }
                }
                await context.SaveChangesAsync();

                var klijent = await context.Users.Where(x => x.UserName == "klijent").FirstOrDefaultAsync();
                var parTerminaZaRezervaciju = await context.Termini.Where(x => x.Pocetak.Hour == 16 && x.ProstorijaId == stonoteniskaDvorana.Id).ToListAsync();
                foreach (var t in parTerminaZaRezervaciju)
                {
                    await mediator.Send(new CreateRezervacijuCommand { KorisnikId = klijent.Id, TerminId = t.Id });
                }

            }
        }
    }
}
