using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DB.Models;
using Repository.Interfaces;
using Service.DTOs.Pagination;
using Service.DTOs.Story;
using Service.Interfaces;

namespace Service
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;

        public StoryService(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StoryDto>> GetStories(StoryParameterDto storyParameterDto)
        {
            var pageNumber = storyParameterDto.PageNumber;
            var pageSize = storyParameterDto.PageSize;

            var stories = await _storyRepository.GetStories(pageNumber, pageSize);
            
            var storiesDto = _mapper.Map<IEnumerable<StoryDto>>(stories);
            
            return storiesDto;
        }

        public async Task<StoryDto> GetStory(int id)
        {
            var story = await _storyRepository.GetStory(id);

            var storyDto = _mapper.Map<StoryDto>(story);
            
            return storyDto;
        }

        public async Task<bool> CreateStory(CreateStoryDto createStoryDto)
        {
            var story = _mapper.Map<Story>(createStoryDto);

            return await _storyRepository.CreateStory(story);
        }

        public async Task<bool> UpdateStory(UpdateStoryDto updateStoryDto)
        {
            var story = _mapper.Map<Story>(updateStoryDto);

            return await _storyRepository.UpdateStory(story);
        }

        public async Task<bool> DeleteStory(StoryDto storyDto)
        {
            var story = _mapper.Map<Story>(storyDto);
            
            return await _storyRepository.DeleteStory(story);
        }

        public async Task<bool> StoryExists(int storyId)
        {
            return await _storyRepository.StoryExists(storyId);
        }
    }
}