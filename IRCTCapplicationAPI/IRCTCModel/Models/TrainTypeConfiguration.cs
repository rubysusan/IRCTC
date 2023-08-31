using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTCModel.Models
{
    public class TrainTypeConfiguration : IEntityTypeConfiguration<TrainType>
    {
        public void Configure(EntityTypeBuilder<TrainType> builder)
        {
            builder.Property(x => x.TypeName).IsRequired();
            builder.Property(x => x.TypeName).HasMaxLength(50);

        }
    }
}
