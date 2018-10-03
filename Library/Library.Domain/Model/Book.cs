using System.Collections.Generic;

namespace Library.Domain.Model
{
    public class Book: Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }

        public List<Allocation> Allocations { get; set; }
        public User User { get; set; }
    }
}
