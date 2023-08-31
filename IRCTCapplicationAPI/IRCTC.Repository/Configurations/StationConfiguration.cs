using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRCTCModel.Models;

namespace IRCTC.Repository.Configurations
{
    public class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.Property(x => x.StationName).IsRequired();
            builder.Property(x => x.StationName).HasMaxLength(50);

        }
    }
}
