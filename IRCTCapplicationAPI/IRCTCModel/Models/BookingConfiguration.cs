using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(x => x.SeatId).IsRequired();
            builder.Property(x => x.SeatTypeId).IsRequired();
            builder.Property(x => x.TrainClassId).IsRequired();
            builder.Property(x => x.FromStop).IsRequired();
            builder.Property(x => x.ToStop).IsRequired();
            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.Preference).IsRequired();
            builder.Property(x => x.Preference).HasMaxLength(50);
            builder.Property(x => x.TotalCost).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

        }
    }
}
