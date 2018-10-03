using Library.Domain.Enum;
using System.Collections.Generic;

namespace Library.Domain.Model
{
    public class UserRole
    {
        public UserRoleEnum Id { get; set; }
        public string Role { get; set; }

        public List<User> Users { get; set; }
    }
}
