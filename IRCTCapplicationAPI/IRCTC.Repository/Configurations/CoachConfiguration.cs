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
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.Property(x => x.CoachId).ValueGeneratedNever();          
            builder.Property(x => x.CoachName).IsRequired();
            builder.Property(x => x.CoachName).HasMaxLength(50);
            builder.Property(x => x.BaseCharge).IsRequired();
            builder.HasData(new Coach[]
            {
                new Coach(CoachEnum.ACFirstClass,100.0),
                new Coach(CoachEnum.ExecChairCar,200.0),
                new Coach(CoachEnum.ACChairCar,150.0),
                new Coach(CoachEnum.Sleeper,80.0),
                new Coach(CoachEnum.SecondSitting,50.0),
                new Coach(CoachEnum.ACSecondTier,130.0),
                new Coach(CoachEnum.ACThirdTier,150.0),
                new Coach(CoachEnum.ACThreeEconomy,85.0)
            });
        }
    }
}
