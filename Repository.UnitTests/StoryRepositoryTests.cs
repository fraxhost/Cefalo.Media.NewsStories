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
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly ApplicationDbContext _storiesContext;
        private readonly StoryRepository _repositoryUnderTest;
        
        public StoryRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "NewsStoriesDbTest")
                .Options;
            
            _storiesContext = new ApplicationDbContext(_options);
            _repositoryUnderTest = new StoryRepository(_storiesContext);
        }

        
        
        [Theory]
        [InlineData("author_id_1")]
        public async Task GetTotalStoriesByAuthor_WhenAuthorIsFound_ReturnsTotalStoriesOfAuthor(string authorId)
        {
            // Arrange
            var newStory = new Story()
            {
                Id = 1,
                Title = "Story 1",
                Body = "Body of Story 1",
                PublishedDate = Convert.ToDateTime("2021-06-24T04:45:23.2321927Z"),
                AuthorId = authorId
            };
            
            await _repositoryUnderTest.CreateStory(newStory);
            
            // Act
            var totalStories = await _repositoryUnderTest.GetTotalStoriesByAuthor(authorId);
            
            // Assert
            Assert.Equal(1, totalStories);
        }
        
        [Theory]
        [InlineData("author_id_1")]
        public async Task GetTotalStoriesByAuthor_WhenAuthorIsNotFound_ReturnsZero(string authorId)
        {
            // Arrange
            var newStory = new Story()
            {
                Id = 1,
                Title = "Story 1",
                Body = "Body of Story 1",
                PublishedDate = Convert.ToDateTime("2021-06-24T04:45:23.2321927Z"),
                AuthorId = Guid.NewGuid().ToString()
            };
            
            await _repositoryUnderTest.CreateStory(newStory);
            
            // Act
            var totalStories = await _repositoryUnderTest.GetTotalStoriesByAuthor(authorId);
            
            // Assert
            Assert.Equal(0, totalStories);
        }
        
        [Fact]
        public async Task GetTotalStories_WhenTotalStoriesIsQueried_ReturnsTotalStories()
        {
            // Arrange
            var newStory = new Story()
            {
                Id = 1,
                Title = "Story 1",
                Body = "Body of Story 1",
                PublishedDate = Convert.ToDateTime("2021-06-24T04:45:23.2321927Z"),
            };
            
            await _repositoryUnderTest.CreateStory(newStory);
            
            // Act
            var totalStories = await _repositoryUnderTest.GetTotalStories();

            // Assert
            Assert.Equal(1, totalStories);
        }
    }
}