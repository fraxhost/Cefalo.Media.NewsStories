using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.User;
using Service.Interfaces;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly ITokenService _tokenService;

        
        public AccountsController(IAccountsService accountsService, ITokenService tokenService)
        {
            _accountsService = accountsService;
            _tokenService = tokenService;
        }

        
        // TODO: Replace all model classes with DTOs in controller 
        
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var userCreated = await _accountsService.CreateUser(registerDto);

            if (!userCreated.identityResult.Succeeded)
            {
                foreach (var error in userCreated.identityResult.Errors)
                {
                    ModelState.AddModelError("Error", error.Description);
                }

                return StatusCode(500, ModelState);
            }
                
            var roleAssigned = await _accountsService.AssignRole(userCreated.user, registerDto);
                
            if (!roleAssigned.Succeeded)
            {
                foreach (var error in roleAssigned.Errors)
                {
                    ModelState.AddModelError("Error", error.Description);
                }

                return StatusCode(500, "Role assigning failed!");
            }
            
            await _accountsService.SignIn(userCreated.user, false);

            var userDto = new AuthenticationDto
            {
                UserId = userCreated.user.UserName,
                Token = await _tokenService.CreateToken(userCreated.user),
            };
            
            return StatusCode(201, userDto);
        }

        
        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationDto>> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _accountsService.FindUserByName(loginDto);

            if (user == null)
            {
                return StatusCode(404, "Invalid username");
            }

            if (await _accountsService.CheckPassword(user, loginDto))
            {
                return Ok(new AuthenticationDto
                {
                    UserId = user.UserName,
                    Token = await _tokenService.CreateToken(user)
                });
            }

            return StatusCode(404, "Invalid password");
        }

        
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _accountsService.FindUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _accountsService.DeleteUser(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}