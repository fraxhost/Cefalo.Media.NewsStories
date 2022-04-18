using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.UserName)
                .IsRequired();
            builder.Property(user => user.FullName)
                .IsRequired();
            

            // Seeding
            // builder.HasData(
            //     new User
            //     {
            //     }
            // );
        }
    }
}