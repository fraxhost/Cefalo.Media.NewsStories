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
        Task<IEnumerable<StoryToReturnDto>> GetStories(StoryParameterDto storyParameterDto);
        Task<PaginationToReturnDto> GetPaginatedStories(StoryParameterDto storyParameterDto);
        Task<StoryToReturnDto> GetStory(int id);
        Task<bool> CreateStory(CreateStoryDto createStoryDto, string userId);
        Task<bool> DeleteStory(StoryToReturnDto storyToReturnDto);
        Task<bool> StoryExists(int storyId);
        Task<string> GetAuthorId(int storyId);
        Task<bool> UpdateStory(int storyId, string authorId, UpdateStoryDto updateStoryDto);
    }
}