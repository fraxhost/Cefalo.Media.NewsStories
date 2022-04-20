using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.User
{
    public class LoginDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters")]
        public string Password { get; set; }
    }
}