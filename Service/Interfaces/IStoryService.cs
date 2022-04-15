using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DB.Models;
using Service.DTOs.Pagination;
using Service.DTOs.Story;

namespace Service.Interfaces
{
    public interface IStoryService
    {
        Task<IEnumerable<StoryDto>> GetStories(StoryParameterDto storyParameterDto);
        Task<StoryDto> GetStory(int id);
        Task<bool> CreateStory(CreateStoryDto createStoryDto);
        Task<bool> UpdateStory(UpdateStoryDto updateStoryDto);
        Task<bool> DeleteStory(StoryDto storyDto);
        Task<bool> StoryExists(int storyId);
    }
}