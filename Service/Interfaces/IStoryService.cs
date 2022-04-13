using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DB.Models;
using Service.DTOs.Story;

namespace Service.Interfaces
{
    public interface IStoryService
    {
        Task<IEnumerable<Story>> GetStories();
        Task<Story> GetStory(int id);
        Task<bool> CreateStory(CreateStoryDto createStoryDto);
        Task<bool> UpdateStory(UpdateStoryDto updateStoryDto);
        Task<bool> DeleteStory(Story story);
        Task<bool> StoryExists(int storyId);
    }
}