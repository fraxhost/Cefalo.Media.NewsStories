using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DB.Models;

namespace Repository.Interfaces
{
    public interface IStoryRepository
    {
        Task<int> GetTotalStories();
        Task<Story> GetStoryById(int storyId);
        Task<bool> CreateStory(Story story);
        Task<bool> UpdateStory(Story story);
        Task<bool> DeleteStory(Story story);
        Task<bool> StoryExists(int storyId);
        Task<int> GetTotalStoriesByAuthor(string authorId);
        Task<int> GetTotalStoriesBySearch(string searchString);
        Task<IEnumerable<Story>> GetStories(int pageNumber, int pageSize);
        Task<IEnumerable<Story>> GetStoriesByAuthor(int pageNumber, int pageSize, string authorId);
        Task<IEnumerable<Story>> GetStoriesBySearch(int pageNumber, int pageSize, string searchString);
        Task<bool> Save();
    }
}