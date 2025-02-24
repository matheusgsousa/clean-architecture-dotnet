using clean_arch.Persistence.Repositories.Interfaces;
using clean_arch.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_arch.Tests.ServicesTests.PaymentTests
{
    public abstract class PaymentServiceTestsBase
    {
        protected Mock<IPaymentRepository> _paymentRepositoryMock { get; private set; }
        protected PaymentService _service { get; private set; }
        public PaymentServiceTestsBase()
        {
            _paymentRepositoryMock = new Mock<IPaymentRepository>();

            _service = new PaymentService(
                _paymentRepositoryMock.Object
            );

        }
    }
}
