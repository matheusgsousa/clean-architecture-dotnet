using clean_arch.Domain.Entities;

namespace clean_arch.Persistence.Repositories.Interfaces
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        Task DeleteAll();
    }
}
