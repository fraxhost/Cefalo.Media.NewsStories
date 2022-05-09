using System;
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
            
            
            // Seeding
            // builder.HasData(
            //     new Story
            //     { 
            //         Id = 1,
            //         Title = "Story 1",
            //         Body = "Body of Story 1",
            //         PublishedDate = Convert.ToDateTime("2021-06-24T04:45:23.2321927Z"),
            //         AuthorId = 1  
            //     },
            //     new Story
            //     {
            //         Id = 2,
            //         Title = "Story 2",
            //         Body = "Body of Story 2",
            //         PublishedDate = Convert.ToDateTime("2021-06-24T04:45:23.2321927Z"),
            //         AuthorId = 2  
            //     },
            //     new Story
            //     {
            //         Id = 3,
            //         Title = "Story 3",
            //         Body = "Body of Story 3",
            //         PublishedDate = Convert.ToDateTime("2021-06-24T04:45:23.2321927Z"),
            //         AuthorId = 3  
            //     },
            //     new Story
            //     {
            //         Id = 4,
            //         Title = "Story 4",
            //         Body = "Body of Story 4",
            //         PublishedDate = Convert.ToDateTime("2021-06-24T04:45:23.2321927Z"),
            //         AuthorId = 4  
            //     },
            //     new Story
            //     {
            //         Id = 5,
            //         Title = "Story 5",
            //         Body = "Body of Story 5",
            //         PublishedDate = Convert.ToDateTime("2021-06-24T04:45:23.2321927Z"),
            //         AuthorId = 5  
            //     }
            // );
        }
    }
}