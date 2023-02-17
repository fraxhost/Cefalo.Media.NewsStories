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

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users
                .ToListAsync();
        }

        public async Task<User> GetUser(string userId)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<bool> CreateUser(User user)
        {
            await _dbContext.Users
                .AddAsync(user);

            return await Save();
        }

        public async Task<bool> UpdateUser(User user)
        {
            _dbContext.Users
                .Update(user);

            return await Save();
        }

        public async Task<bool> DeleteAuthor(User user)
        {
            _dbContext.Users
                .Remove(user);

            return await Save();
        }

        public async Task<bool> UserExists(string userId)
        {
            return await _dbContext.Users
                .AnyAsync(user => user.NormalizedUserName.ToLower() == userId.ToLower());
        }
        
        public async Task<bool> Save()
        {
            return await _dbContext
                .SaveChangesAsync() >= 0;
        }
    }
}