using Library.Domain.Enum;

namespace Library.Domain.Model
{
    public class Fine: Auditable
    {
        public int Id { get; set; }
        public int BorrowId { get; set; }
        public FineStatusEnum StatusId { get; set; }

        public Allocation Allocation { get; set; }
        public FineStatus FineStatus { get; set; }
    }
}