using System;
using System.Collections.Generic;
using System.Linq;
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


        public async Task<IEnumerable<StoryToReturnDto>> GetStories(StoryParameterDto storyParameterDto)
        {
            var pageNumber = storyParameterDto.PageNumber;
            var pageSize = storyParameterDto.PageSize;

            var stories = await _storyRepository.GetStories(pageNumber, pageSize);

            // var storiesDto = _mapper.Map<IEnumerable<StoryToReturnDto>>(stories);

            var storiesDto = new List<StoryToReturnDto>();

            foreach (var story in stories)
            {
                var storyDto = new StoryToReturnDto
                {
                    Id = story.Id,
                    AuthorId = story.AuthorId,
                    AuthorName = story.Author.FullName,
                    Body = story.Body,
                    PublishedDate = story.PublishedDate,
                    Title = story.Title
                };

                storiesDto.Add(storyDto);
            }

            return storiesDto;
        }

        public async Task<PaginationToReturnDto> GetPaginatedStories(StoryParameterDto storyParameterDto)
        {
            var pageNumber = storyParameterDto.PageNumber;
            var pageSize = storyParameterDto.PageSize;

            var stories = await _storyRepository.GetStories(pageNumber, pageSize);

            // var storiesDto = _mapper.Map<IEnumerable<StoryToReturnDto>>(stories);

            var storiesDto = new List<StoryToReturnDto>();

            foreach (var story in stories)
            {
                var storyDto = new StoryToReturnDto
                {
                    Id = story.Id,
                    AuthorId = story.AuthorId,
                    AuthorName = story.Author.FullName,
                    Body = story.Body,
                    PublishedDate = story.PublishedDate,
                    Title = story.Title
                };

                storiesDto.Add(storyDto);
            }

            var totalStories = await _storyRepository.GetTotalStories();
            var totalPages = (int) Math.Ceiling((decimal) totalStories / pageSize);

            return new PaginationToReturnDto
            {
                Data = storiesDto,
                Count = totalStories,
                TotalPage = totalPages,
                CurrentPage = pageNumber
            };
        }

        public async Task<StoryToReturnDto> GetStory(int id)
        {
            var story = await _storyRepository.GetStory(id);

            var storyDto = _mapper.Map<StoryToReturnDto>(story);

            return storyDto;
        }


        public async Task<bool> CreateStory(CreateStoryDto createStoryDto, string userId)
        {
            var story = _mapper.Map<Story>(createStoryDto);
            story.AuthorId = userId;

            return await _storyRepository.CreateStory(story);
        }


        public async Task<bool> UpdateStory(int storyId, string authorId, UpdateStoryDto updateStoryDto)
        {
            var story = _mapper.Map<Story>(updateStoryDto);

            story.Id = storyId;
            story.AuthorId = authorId;

            return await _storyRepository.UpdateStory(story);
        }


        public async Task<bool> DeleteStory(StoryToReturnDto storyToReturnDto)
        {
            var story = _mapper.Map<Story>(storyToReturnDto);

            return await _storyRepository.DeleteStory(story);
        }


        public async Task<bool> StoryExists(int storyId)
        {
            return await _storyRepository.StoryExists(storyId);
        }


        public async Task<string> GetAuthorId(int storyId)
        {
            var story = await _storyRepository.GetStory(storyId);

            return story.AuthorId;
        }
    }
}