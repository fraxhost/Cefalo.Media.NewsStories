using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .IsRequired();
            builder.Property(user => user.UserId)
                .IsRequired();
            builder.Property(user => user.FullName)
                .IsRequired();
            builder.Property(user => user.PasswordSalt)
                .IsRequired();
            builder.Property(user => user.PasswordHash)
                .IsRequired();
        }
    }
}