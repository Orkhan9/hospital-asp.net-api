using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Hospital.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
        public int RoleId  { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}