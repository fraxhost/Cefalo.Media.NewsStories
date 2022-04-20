using System.Threading.Tasks;
using DB.Models;
using Microsoft.AspNetCore.Identity;
using Service.DTOs.User;
using Service.Interfaces;

namespace Service
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountsService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        

        public async Task<(User user, IdentityResult identityResult)> CreateUser(RegisterDto registerDto)
        {
            var user = new User
            {
                FullName = registerDto.FullName,
                UserName = registerDto.UserId
            };
            
            return (user: user, identityResult: await _userManager.CreateAsync(user, registerDto.Password));
        }


        public async Task<IdentityResult> AssignRole(User user, RegisterDto registerDto)
        {
            return await _userManager.AddToRolesAsync(user, registerDto.Roles);
        }
        
        
        public async Task SignIn(User user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent: isPersistent);
        }


        public async Task<User> FindUserByName(LoginDto loginDto)
        {
            return await _userManager.FindByNameAsync(loginDto.UserId);
        }
        
        
        public async Task<User> FindUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
        
        
        public async Task<bool> CheckPassword(User user, LoginDto loginDto)
        {
            return await _userManager.CheckPasswordAsync(user, loginDto.Password);
        }


        public async Task<IdentityResult> DeleteUser(User user)
        {
            return await _userManager.DeleteAsync(user);
        }
    }
}