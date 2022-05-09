using System;
using System.Threading.Tasks;
using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Repository.UnitTests
{
    public class StoryRepositoryTests
    {
        public readonly DbContextOptions<ApplicationDbContext> options;

        public StoryRepositoryTests()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "NewsStoriesDbTest")
                .Options;
        }
        
        [Fact]
        public async Task GetTotalStories_WhenTotalStoriesIsQueried_ReturnsTotalStories()
        {
            // Arrange
            var storiesContext = new ApplicationDbContext(options);
            var storiesRepository = new StoryRepository(storiesContext);

            var newStory = new Story()
            {
                Id = 1,
                Title = "Story 1",
                Body = "Body of Story 1",
                PublishedDate = Convert.ToDateTime("2021-06-24T04:45:23.2321927Z"),
            };
            
            await storiesRepository.CreateStory(newStory);
            
            // Act
            var totalStories = await storiesRepository.GetTotalStories();

            // Assert
            Assert.Equal(1, totalStories);
        }
    }
}