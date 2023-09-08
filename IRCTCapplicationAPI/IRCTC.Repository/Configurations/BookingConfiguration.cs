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
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.BookingId);
            builder.Property(x => x.TrainClassId).IsRequired();
            builder.Property(x => x.FromStop).IsRequired();
            builder.Property(x => x.ToStop).IsRequired();
            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.TotalCost).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.HasOne(x => x.TrainClass)
                   .WithMany(y => y.Bookings)
                   .HasForeignKey(x => x.TrainClassId);
            builder.HasOne(x => x.FromTrainStop)
                   .WithMany(y => y.FromBookings)
                   .HasForeignKey(x => x.FromStop);
            builder.HasOne(x => x.ToTrainStop)
                   .WithMany(y => y.ToBookings)
                   .HasForeignKey(x => x.ToStop);
            builder.HasOne(x => x.User)
                   .WithMany(y => y.Bookings)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
