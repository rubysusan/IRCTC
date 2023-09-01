using IRCTCModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  IRCTCModel.Enums;


namespace IRCTC.Repository.Configurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {

            builder.Property(x => x.UserTypeId).ValueGeneratedNever();
            builder.Property(x => x.TypeName).IsRequired();
            builder.Property(x => x.TypeName).HasMaxLength(50);
            builder.HasData( new UserType[] {
            new UserType(UserTypeEnum.Passenger),
            new UserType(UserTypeEnum.TTE)
        });

        }
    }
}
