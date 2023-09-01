using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRCTCModel.Models;
using System.Security.Cryptography.X509Certificates;
using IRCTCModel.Enums;

namespace IRCTC.Repository.Configurations
{
    public class TrainTypeConfiguration : IEntityTypeConfiguration<TrainType>
    {
        public void Configure(EntityTypeBuilder<TrainType> builder)
        {
            builder.Property(x=>x.TrainTypeID).ValueGeneratedNever();
            
            builder.Property(x => x.TypeName).IsRequired();
            builder.Property(x => x.TypeName).HasMaxLength(50);
            builder.HasData(new TrainType[] {
                            new TrainType(TrainTypeEnum.Janshatabdi),
                            new TrainType(TrainTypeEnum.Shatabdi),
                            new TrainType(TrainTypeEnum.Antyodaya),
                            new TrainType(TrainTypeEnum.Intercity),
                            new TrainType(TrainTypeEnum.Express)
                        });
            

        }
    }
}
