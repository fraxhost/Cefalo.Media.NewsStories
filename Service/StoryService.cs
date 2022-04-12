using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DB.Models;
using Repository.Interfaces;
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

        public async Task<IEnumerable<Story>> GetStories()
        {
            return await _storyRepository.GetStories();
        }

        public async Task<Story> GetStory(int id)
        {
            return await _storyRepository.GetStory(id);
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

        public async Task<bool> DeleteStory(Story story)
        {
            return await _storyRepository.DeleteStory(story);
        }

        public async Task<bool> StoryExists(int storyId)
        {
            return await _storyRepository.StoryExists(storyId);
        }
    }
}