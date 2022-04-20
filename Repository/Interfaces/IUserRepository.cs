using System.Collections.Generic;
using System.Threading.Tasks;
using DB.Models;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string userId);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteAuthor(User user);
        Task<bool> UserExists(string userId);
        Task<bool> Save();
    }
}