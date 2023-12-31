﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRCTCModel.Models;

namespace IRCTC.Repository.Configurations
{
    public class TrainClassConfiguration : IEntityTypeConfiguration<TrainClass>
    {
        public void Configure(EntityTypeBuilder<TrainClass> builder)
        {
            builder.HasKey(x => x.TrainClassId);
            builder.Property(x => x.TrainId).IsRequired();
            builder.HasOne(x => x.Train)
                   .WithMany(y => y.TrainClasses)
                   .HasForeignKey(x => x.TrainId);
            builder.Property(x => x.ClassId).IsRequired();
            builder.HasOne(x => x.Coach)
                   .WithMany(y => y.TrainClasses)
                   .HasForeignKey(x => x.ClassId);
        }
    }
}
