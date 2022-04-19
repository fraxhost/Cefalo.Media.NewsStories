using System.Threading.Tasks;
using DB.Models;
using Microsoft.AspNetCore.Identity;
using Service.DTOs;
using Service.DTOs.User;

namespace Service.Interfaces
{
    public interface IAccountsService
    {
        Task<IdentityResult> Register(RegisterDto registerDto);
        Task<User> Login(LoginDto loginDto);
        Task<User> GetUser(LoginDto loginDto);
        Task<bool> UserExists(RegisterDto registerDto);
        Task<bool> UserExists(LoginDto loginDto);
        // bool PasswordValidation(ApplicationUser applicationUser, LoginDto loginDto);
    }
}