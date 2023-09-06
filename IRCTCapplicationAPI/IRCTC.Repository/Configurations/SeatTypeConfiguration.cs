using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRCTCModel.Models;
using IRCTCModel.Enums;

namespace IRCTC.Repository.Configurations
{
    public class SeatTypeConfiguration : IEntityTypeConfiguration<SeatType>
    {
        public void Configure(EntityTypeBuilder<SeatType> builder)
        {
            builder.Property(x => x.SeatTypeId).ValueGeneratedNever();
            builder.Property(x => x.TypeName).IsRequired();
            builder.Property(x => x.TypeName).HasMaxLength(50);
            builder.HasData(new SeatType[]
            {
                new SeatType(SeatTypeEnum.LowerBirth),
                new SeatType(SeatTypeEnum.UpperBirth),
                new SeatType(SeatTypeEnum.MiddleBirth),
                new SeatType(SeatTypeEnum.WindowSeat),
                new SeatType(SeatTypeEnum.MiddleSeat),
                new SeatType(SeatTypeEnum.AisleSeat)
            });
        }
    }
}
