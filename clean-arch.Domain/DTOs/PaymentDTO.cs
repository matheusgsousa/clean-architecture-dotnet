using clean_arch.Domain.Entities.Base;

namespace clean_arch.Domain.DTOs
{
    public class PaymentDTO : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
