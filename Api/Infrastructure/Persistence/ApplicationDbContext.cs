using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Common;
using SportskiCentarRS2.Domain.Entities;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<Korisnik,KorisnickaUloga,int>,IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(DbContextOptions options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Notifikacija> Notifikacije { get ; set ; }
        public DbSet<Ocjena> Ocjene { get ; set ; }
        public DbSet<Oprema> Oprema { get ; set ; }
        public DbSet<Prostorija> Prostorije { get ; set ; }
        public DbSet<ProstorijaOprema> ProstoroijeOpreme { get ; set ; }
        public DbSet<Rezervacija> Rezervacije { get ; set ; }
        public DbSet<Termin> Termini { get ; set ; }
        public DbSet<Uplata> Uplate { get ; set ; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.KreoiraoKorisnikId = _currentUserService.UserId == 0 ? (await Users.Where(x => x.UserName == "administrator").FirstOrDefaultAsync(cancellationToken)).Id : _currentUserService.UserId;
                        entry.Entity.KreiranoDatumVrijeme = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.ZadnjiIzmijenioKorisnikId = _currentUserService.UserId == 0 ? (await Users.Where(x => x.UserName == "administrator").FirstOrDefaultAsync(cancellationToken)).Id : _currentUserService.UserId;
                        entry.Entity.IzmijenjenoDatumVrijeme = DateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
