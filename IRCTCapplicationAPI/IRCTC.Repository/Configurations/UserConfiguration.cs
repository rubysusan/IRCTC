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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.IdentityCardID).IsRequired();
            builder.Property(x => x.IdentityCardID).HasMaxLength(50);
            builder.Property(x => x.UserTypeID).IsRequired();
            builder.Property(x => x.UserTypeID).HasMaxLength(50);

        }
    }
}
