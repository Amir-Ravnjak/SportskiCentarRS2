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
    public class OcjenaConfiguration : IEntityTypeConfiguration<Ocjena>
    {
        public void Configure(EntityTypeBuilder<Ocjena> builder)
        {
            builder.OwnsOne(x => x.Vrijednost);
        }
    }
}
