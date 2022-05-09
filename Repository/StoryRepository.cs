using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository
{
    public class StoryRepository : IStoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Story>> GetStories(int pageNumber, int pageSize)
        {
            return await _dbContext.Stories
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(story => story.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<Story>> GetStoriesByAuthor(int pageNumber, int pageSize, string authorId)
        {
            return await _dbContext.Stories
                .Where(story => story.AuthorId == authorId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(story => story.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<Story>> GetStoriesBySearch(int pageNumber, int pageSize, string searchString)
        {
            int numericValue;
            bool isNumber = int.TryParse(searchString, out numericValue);
            
            return await _dbContext.Stories
                .Where(
                    story =>
                        story.AuthorId.Contains(searchString) ||
                        (isNumber ? story.Id.Equals(numericValue) : false) ||
                        story.Title.Contains(searchString) ||
                        story.Body.Contains(searchString) ||
                        story.PublishedDate.Equals(searchString) ||
                        story.Author.FullName.Contains(searchString) ||
                        story.Author.NormalizedUserName.Contains(searchString.ToUpper())
                )
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(story => story.Author)
                .ToListAsync();
        }

        public async Task<int> GetTotalStories()
        {
            return await _dbContext.Stories.CountAsync();
        }

        public async Task<int> GetTotalStoriesByAuthor(string authorId)
        {
            return await _dbContext.Stories
                .Where(story => story.AuthorId == authorId)
                .CountAsync();
        }

        public async Task<int> GetTotalStoriesBySearch(string searchString)
        {
            int numericValue;
            bool isNumber = int.TryParse(searchString, out numericValue);
            
            return await _dbContext.Stories
                .Where(
                    story => story.AuthorId.Contains(searchString) ||
                             (isNumber ? story.Id.Equals(numericValue) : false) ||
                             story.Title.Contains(searchString) ||
                             story.Body.Contains(searchString) ||
                             story.PublishedDate.Equals(searchString) ||
                             story.Author.FullName.Contains(searchString) ||
                             story.Author.NormalizedUserName.Contains(searchString.ToUpper())
                ).CountAsync();
        }

        public async Task<Story> GetStory(int storyId)
        {
            return await _dbContext.Stories
                .AsNoTracking()
                .FirstOrDefaultAsync(story => story.Id == storyId);
        }

        public async Task<bool> CreateStory(Story story)
        {
            await _dbContext.Stories
                .AddAsync(story);

            return await Save();
        }

        public async Task<bool> UpdateStory(Story story)
        {
            _dbContext.Stories
                .Update(story);

            return await Save();
        }

        public async Task<bool> DeleteStory(Story story)
        {
            _dbContext.Stories
                .Remove(story);

            return await Save();
        }

        public async Task<bool> StoryExists(int storyId)
        {
            return await _dbContext.Stories
                .AnyAsync(story => story.Id == storyId);
        }

        public async Task<bool> Save()
        {
            return await _dbContext
                .SaveChangesAsync() >= 0;
        }
    }
}