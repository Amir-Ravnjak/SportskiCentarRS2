using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportskiCentarRS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Infrastructure.Persistence.Configurations
{
    public class NotifikacijaConfiguration : IEntityTypeConfiguration<Notifikacija>
    {
        public void Configure(EntityTypeBuilder<Notifikacija> builder)
        {
            builder.HasOne(x => x.Posiljalac).WithMany().HasForeignKey(x => x.PosiljalacId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Primalac).WithMany().HasForeignKey(x => x.PrimalacId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
