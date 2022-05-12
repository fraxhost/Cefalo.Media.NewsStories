using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using DB.Models;
using Moq;
using Repository.Interfaces;
using Service.DTOs.Story;
using Xunit;

namespace Service.UnitTests
{
    public class StoriesServiceTests
    {
        private readonly StoryService _sut;
        private Mock<IStoryRepository> _mockStoryRepository;
        private Mock<IMapper> _mockMapper;
        
        public StoriesServiceTests()
        {
            _mockStoryRepository = new Mock<IStoryRepository>();
            _mockMapper = new Mock<IMapper>();

            _sut = new StoryService(_mockStoryRepository.Object, _mockMapper.Object);
        }
        
        [Theory]
        [InlineData(1)]
        public async Task GetStoryById_WhenCalled_ReturnsStoryToReturnDtoTypeObject(int id)
        {
            // Arrange
            var createdStory = new Story
            {
                Id = id
            };

            var createdStoryDto = new StoryToReturnDto
            {
                Id = id
            };

            _mockStoryRepository.Setup(storyRepo => storyRepo.GetStoryById(id)).ReturnsAsync(createdStory);
            _mockMapper.Setup(storyMapper => storyMapper.Map<StoryToReturnDto>(createdStory)).Returns(createdStoryDto);
            
            // Act
            var foundStoryDto = await _sut.GetStoryById(id);
            
            // Assert
            Assert.IsType<StoryToReturnDto>(foundStoryDto);
        }
        
        [Theory]
        [InlineData(1)]
        public async Task GetStoryById_WhenStoryIsFound_ReturnsStory(int id)
        {
            // Arrange
            var createdStory = new Story
            {
                Id = 1
            };

            var createdStoryDto = new StoryToReturnDto
            {
                Id = 1
            };

            _mockStoryRepository.Setup(storyRepo => storyRepo.GetStoryById(id)).ReturnsAsync(createdStory);
            _mockMapper.Setup(storyMapper => storyMapper.Map<StoryToReturnDto>(createdStory)).Returns(createdStoryDto);
            
            // Act
            var foundStoryDto = await _sut.GetStoryById(id);
            
            // Assert
            Assert.Equal(createdStoryDto, foundStoryDto);
        }
        
        [Theory]
        [InlineData(1)]
        public async Task GetStoryById_WhenStoryIsNotFound_ReturnsNull(int id)
        {
            // Arrange
            _mockStoryRepository.Setup(storyRepo => storyRepo.GetStoryById(id)).ReturnsAsync((Story) null);
            _mockMapper.Setup(storyMapper => storyMapper.Map<StoryToReturnDto>(null)).Returns((StoryToReturnDto) null);
            
            // Act
            var foundStoryDto = await _sut.GetStoryById(id);
            
            // Assert
            Assert.Null(foundStoryDto);
        }
    }
}