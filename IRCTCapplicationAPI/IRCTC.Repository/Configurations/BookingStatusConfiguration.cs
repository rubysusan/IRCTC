using IRCTCModel.Enums;
using IRCTCModel.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRCTC.Repository.Configurations
{
    public class BookingStatusConfiguration : IEntityTypeConfiguration<BookingStatus>
    {
        public void Configure(EntityTypeBuilder<BookingStatus> builder)
        {
            builder.Property(x => x.BookingStatusId).ValueGeneratedNever();
            builder.Property(x => x.BookingStatusId).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.HasData(new BookingStatus[]
            {
                new BookingStatus(BookingStatusEnum.Confirmed),
                new BookingStatus(BookingStatusEnum.Cancelled)
            });
        }



    }
}
