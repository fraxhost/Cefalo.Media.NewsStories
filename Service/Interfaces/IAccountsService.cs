using System;
using System.Threading.Tasks;
using DB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.DTOs.User;

namespace Service.Interfaces
{
    public interface IAccountsService
    {
        Task<(User user, IdentityResult identityResult)> CreateUser(RegisterDto registerDto);
        Task<IdentityResult> AssignRole(User user, RegisterDto registerDto);
        Task<bool> CheckPassword(User user, LoginDto loginDto);
        Task<User> FindUserByName(LoginDto loginDto);
        Task<User> FindUserById(string id);
        Task<IdentityResult> DeleteUser(User user);
        Task SignIn(User user, bool isPersistent);
    }
}