using IRCTCModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTC.Repository.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(x => x.PassengerId);
            builder.Property(x=>x.PassengerName).IsRequired();
            builder.Property(x => x.PassengerName).HasMaxLength(50);
            builder.Property(x => x.SeatId).IsRequired();
            builder.Property(x => x.BookingId).IsRequired();
            builder.HasOne(x => x.Seat)
                   .WithOne(y => y.Passenger)
                   .HasForeignKey<Passenger>(x => x.SeatId);
            builder.HasOne(x=>x.Booking)
                   .WithMany(y=>y.Passengers)
                   .HasForeignKey(x=>x.BookingId);
        }
    }
}
