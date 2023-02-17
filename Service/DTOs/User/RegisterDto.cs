using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs.User
{
    public class RegisterDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters")]
        public string Password { get; set; }
        [Required]
        public IEnumerable<string> Roles { get; set; }
    }
}