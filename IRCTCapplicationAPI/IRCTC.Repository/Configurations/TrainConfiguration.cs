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
    public class TrainConfiguration : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder.HasKey(x => x.TrainId);
            builder.Property(x => x.TrainName).IsRequired();
            builder.Property(x => x.TrainName).HasMaxLength(50);
            builder.Property(x => x.FromStationId).IsRequired();
            builder.Property(x => x.ToStationId).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.DepartureTime).IsRequired();
            builder.Property(x => x.ReachingTime).IsRequired();
            builder.Property(x=>x.TrainTypeID).IsRequired();
            builder.HasOne(x => x.TrainType)
                   .WithMany(y => y.Trains)
                   .HasForeignKey(x => x.TrainTypeID);
            builder.HasOne(x => x.FromStation)
                   .WithMany(y => y.FromTrains)
                   .HasForeignKey(x => x.FromStationId);
            builder.HasOne(x => x.ToStation)
                  .WithMany(y => y.ToTrains)
                  .HasForeignKey(x => x.ToStationId);

        }
    }
}
