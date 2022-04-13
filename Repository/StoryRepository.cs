using System.Collections.Generic;
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
        
        public async Task<IEnumerable<Story>> GetStories()
        {
            return await _dbContext.Stories
                .AsNoTracking()
                .ToListAsync();
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