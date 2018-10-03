using Library.Domain.Enum;
using System.Collections.Generic;

namespace Library.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public UserRoleEnum RoleId { get; set; }

        public List<Book> Books { get; set; }
        public List<Allocation> Allocations { get; set; }
        public UserRole UserRole { get; set; }
    }
}
