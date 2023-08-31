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
    public class TrainStopConfiguration : IEntityTypeConfiguration<TrainStop>
    {
        public void Configure(EntityTypeBuilder<TrainStop> builder)
        {
            builder.Property(x => x.TrainId).IsRequired();
            builder.Property(x => x.StopStationId).IsRequired();
            builder.Property(x => x.ReachingTime).IsRequired();
            builder.Property(x => x.StationCount).IsRequired();


        }
    }
}
