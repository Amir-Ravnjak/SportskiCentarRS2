using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Korisnik> Users { get; set; }
        DbSet<KorisnickaUloga> Roles { get; set; }
        DbSet<IdentityUserRole<int>> UserRoles { get; set; }
        DbSet<Notifikacija> Notifikacije { get; set; }
        DbSet<Ocjena> Ocjene { get; set; }
        DbSet<Oprema> Oprema { get; set; }
        DbSet<Prostorija> Prostorije { get; set; }
        DbSet<ProstorijaOprema> ProstoroijeOpreme { get; set; }
        DbSet<Rezervacija> Rezervacije { get; set; }
        DbSet<Termin> Termini { get; set; }
        DbSet<Uplata> Uplate { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
