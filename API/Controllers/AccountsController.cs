using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DB;
using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.DTOs;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountsController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _accountService.UserExists(registerDto))
            {
                return BadRequest("UserId is taken!");
            }

            var user = await _accountService.Register(registerDto);

            if (user == null)
            {
                return StatusCode(500);
            }

            var token = _tokenService.CreateToken(user);
            
            return new UserDto
            {
                UserId = user.UserId,
                Token = token
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _accountService.GetUser(loginDto);

            if (user == null)
            {
                return Unauthorized("Invalid username!");
            }

            if (!_accountService.PasswordValidation(user, loginDto))
            {
                return Unauthorized("Invalid password!");
            }
            
            return new UserDto
            {
                UserId = user.UserId,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}