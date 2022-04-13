using System.Threading.Tasks;
using DB.Models;
using Service.DTOs;
using Service.DTOs.User;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        Task<User> Register(RegisterDto registerDto);
        Task<User> Login(LoginDto loginDto);
        Task<User> GetUser(LoginDto loginDto);
        Task<bool> UserExists(RegisterDto registerDto);
        Task<bool> UserExists(LoginDto loginDto);
        bool PasswordValidation(User user, LoginDto loginDto);
    }
}