using Library.Domain.Enum;
using System.Collections.Generic;

namespace Library.Domain.Model
{
    public class FineStatus
    {
        public FineStatusEnum Id { get; set; }
        public string Status { get; set; }

        public List<Fine> Fines { get; set; }
    }
}
