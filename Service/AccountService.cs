using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DB.Models;
using Repository.Interfaces;
using Service.DTOs;
using Service.DTOs.User;
using Service.Interfaces;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Register(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();

            var user = new User()
            {
                UserId = registerDto.UserId,
                FullName = registerDto.FullName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            if (!await _userRepository.CreateUser(user))
            {
                return null;
            }

            return user;
        }

        public Task<User> Login(LoginDto loginDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetUser(LoginDto loginDto)
        {
            return await _userRepository.GetUser(loginDto.UserId);
        }
        
        public async Task<bool> UserExists(RegisterDto registerDto)
        {
            return await _userRepository.UserExists(registerDto.UserId);
        }
        
        public async Task<bool> UserExists(LoginDto loginDto)
        {
            return await _userRepository.UserExists(loginDto.UserId);
        }

        public bool PasswordValidation(User user, LoginDto loginDto)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}