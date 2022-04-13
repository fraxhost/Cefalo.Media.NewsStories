using System.Collections.Generic;

namespace DB.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual IEnumerable<Story> Stories { get; set; }
    }
}