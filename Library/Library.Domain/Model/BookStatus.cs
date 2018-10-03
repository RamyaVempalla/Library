using Library.Domain.Enum;
using System.Collections.Generic;

namespace Library.Domain.Model
{
    public class BookStatus
    {
        public BookStatusEnum Id { get; set; }
        public string Status { get; set; }

        public List<Allocation> Allocations { get; set; }
    }
}
