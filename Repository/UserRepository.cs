using System.Collections.Generic;
using System.Threading.Tasks;
using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _dbContext.Authors
                .ToListAsync();
        }

        public async Task<Author> GetAuthor(string userId)
        {
            return await _dbContext.Authors
                .FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<bool> CreateAuthor(Author author)
        {
            await _dbContext.Authors
                .AddAsync(author);

            return await Save();
        }

        public async Task<bool> UpdateAuthor(Author author)
        {
            _dbContext.Authors
                .Update(author);

            return await Save();
        }

        public async Task<bool> DeleteAuthor(Author author)
        {
            _dbContext.Authors
                .Remove(author);

            return await Save();
        }

        public async Task<bool> UserExists(string userId)
        {
            return await _dbContext.Authors
                .AnyAsync(user => user.NormalizedUserName.ToLower() == userId.ToLower());
        }
        
        public async Task<bool> Save()
        {
            return await _dbContext
                .SaveChangesAsync() >= 0;
        }
    }
}