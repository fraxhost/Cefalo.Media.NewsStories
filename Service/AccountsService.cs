using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DB.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;
using Service.DTOs;
using Service.DTOs.User;
using Service.Interfaces;

namespace Service
{
    public class AccountsesService : IAccountsService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AccountsesService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        // public async Task<ApplicationUser> Register(RegisterDto registerDto)
        // {
        //     using var hmac = new HMACSHA512();
        //
        //     var user = new ApplicationUser()
        //     {
        //         UserId = registerDto.UserId,
        //         FullName = registerDto.FullName,
        //         // PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        //         // PasswordSalt = hmac.Key
        //     };
        //
        //     if (!await _authorRepository.CreateUser(user))
        //     {
        //         return null;
        //     }
        //
        //     return user;
        // }
        //
        // public Task<ApplicationUser> Login(LoginDto loginDto)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public async Task<ApplicationUser> GetUser(LoginDto loginDto)
        // {
        //     return await _authorRepository.GetUser(loginDto.UserId);
        // }
        //
        // public async Task<bool> UserExists(RegisterDto registerDto)
        // {
        //     return await _authorRepository.UserExists(registerDto.UserId);
        // }
        //
        // public async Task<bool> UserExists(LoginDto loginDto)
        // {
        //     return await _authorRepository.UserExists(loginDto.UserId);
        // }

        // public bool PasswordValidation(ApplicationUser applicationUser, LoginDto loginDto)
        // {
        //     using var hmac = new HMACSHA512(applicationUser.PasswordSalt);
        //
        //     var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
        //
        //     for (int i = 0; i < computedHash.Length; i++)
        //     {
        //         if (computedHash[i] != applicationUser.PasswordHash[i])
        //         {
        //             return false;
        //         }
        //     }
        //
        //     return true;
        // }
        public async Task<IdentityResult> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                FullName = registerDto.FullName,
                UserName = registerDto.UserId
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, registerDto.Roles);
            }

            return result;
        }

        public Task<User> Login(LoginDto loginDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUser(LoginDto loginDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UserExists(RegisterDto registerDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UserExists(LoginDto loginDto)
        {
            throw new System.NotImplementedException();
        }
    }
}