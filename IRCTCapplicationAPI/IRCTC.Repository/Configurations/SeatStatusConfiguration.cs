using IRCTCModel.Enums;
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
    public class SeatStatusConfiguration : IEntityTypeConfiguration<SeatStatus>
    {
        public void Configure(EntityTypeBuilder<SeatStatus> builder)
        {
            builder.Property(x=>x.SeatStatusId).ValueGeneratedNever();
            builder.Property(x => x.SeatStatusId).IsRequired();
            builder.Property(x=>x.Status).IsRequired();
            builder.HasData(new SeatStatus[]
            {
                new SeatStatus(SeatStatusEnum.Confirmed),
                new SeatStatus(SeatStatusEnum.ReservationAgainstCancellation),
                new SeatStatus(SeatStatusEnum.GeneralWaitingList),
                new SeatStatus(SeatStatusEnum.TatkalWaitingList),
                new SeatStatus(SeatStatusEnum.TicketCancelled)
            });
        }

        

    }
}
