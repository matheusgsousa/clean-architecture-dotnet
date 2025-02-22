using clean_arch.Domain.Entities.Base;

namespace clean_arch.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
