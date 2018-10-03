using Library.Domain.Enum;
using System;

namespace Library.Domain.Model
{
    public class Allocation : Auditable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public BookStatusEnum StatusId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
        public BookStatus BookStatus { get; set; }
        public Fine Fine { get; set; }

    }
}
