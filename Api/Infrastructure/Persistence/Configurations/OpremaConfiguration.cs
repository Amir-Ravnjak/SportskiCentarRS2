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
    public class OpremaConfiguration : IEntityTypeConfiguration<Oprema>
    {
        public void Configure(EntityTypeBuilder<Oprema> builder)
        {
            builder.OwnsOne(x => x.NaStanju);
        }
    }
}
