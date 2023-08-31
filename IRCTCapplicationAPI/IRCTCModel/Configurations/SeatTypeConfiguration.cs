using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRCTCModel.Models;

namespace IRCTCModel.Configurations
{
    public class SeatTypeConfiguration : IEntityTypeConfiguration<SeatType>
    {
        public void Configure(EntityTypeBuilder<SeatType> builder)
        {
            builder.Property(x => x.TypeName).IsRequired();
            builder.Property(x => x.TypeName).HasMaxLength(50);

        }
    }
}
