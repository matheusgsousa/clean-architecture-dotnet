using clean_arch.Domain.Entities;
using clean_arch.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_arch.Persistence.Repositories
{
    public class PaymentRepository(MySqlDatabaseContext context) : BaseRepository<Payment>(context), IPaymentRepository
    {
        private readonly MySqlDatabaseContext _context = context;
        public async Task DeleteAll()
        {
            var payments = ObjectSet.ToList();
            ObjectSet.RemoveRange(payments);
            await _context.SaveChangesAsync();
        }

    }
}
