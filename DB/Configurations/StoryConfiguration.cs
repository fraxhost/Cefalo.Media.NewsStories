using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Configurations
{
    public class StoryConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.HasKey(story => story.Id);

            builder.Property(story => story.Id)
                .IsRequired();
            builder.Property(story => story.Title)
                .IsRequired();
            builder.Property(story => story.PublishedDate)
                .IsRequired();

            builder.HasOne(story => story.Author)
                .WithMany(user => user.Stories)
                .HasForeignKey(story => story.AuthorId);
        }
    }
}