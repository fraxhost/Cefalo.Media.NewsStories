using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DB.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public IEnumerable<Story> Stories { get; set; }
    }
}