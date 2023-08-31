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
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.Property(x => x.SeatNumber).IsRequired();
            builder.Property(x => x.SeatNumber).HasMaxLength(50);
            builder.Property(x => x.SeatTypeId).IsRequired();
            builder.Property(x => x.TrainClassId).IsRequired();
            builder.Property(x => x.Booked).IsRequired();
        }
    }

}
