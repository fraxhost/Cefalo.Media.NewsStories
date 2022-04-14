using System.Collections.Generic;
using System.Threading.Tasks;
using DB.Models;

namespace Repository.Interfaces
{
    public interface IStoryRepository
    {
        Task<IEnumerable<Story>> GetStories(int pageNumber, int pageSize);
        Task<Story> GetStory(int storyId);
        Task<bool> CreateStory(Story story);
        Task<bool> UpdateStory(Story story);
        Task<bool> DeleteStory(Story story);
        Task<bool> StoryExists(int storyId);
        Task<bool> Save();
    }
}