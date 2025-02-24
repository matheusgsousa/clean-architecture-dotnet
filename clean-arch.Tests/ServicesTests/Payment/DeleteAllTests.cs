using clean_arch.Domain.Entities;
using Moq;


namespace clean_arch.Tests.ServicesTests.PaymentTests
{
    public class DeleteAllTests : PaymentServiceTestsBase
    {
        [Fact]
        public async Task DeleteAllPayments_Success()
        {
            // Arrange
            _paymentRepositoryMock.Setup(x => x.DeleteAll()).Returns(Task.CompletedTask);
            // Act
            var result = await _service.DeleteAllPayments();
            // Assert
            Assert.True(result.Success);
            _paymentRepositoryMock.Verify(x => x.DeleteAll(), Times.Once);
        }

        [Fact]
        public async Task DeleteAllPayments_Fail()
        {
            // Arrange
            _paymentRepositoryMock.Setup(x => x.DeleteAll()).Throws(new Exception("Error"));
            // Act
            var result = await _service.DeleteAllPayments();
            // Assert
            Assert.False(result.Success);
            _paymentRepositoryMock.Verify(x => x.DeleteAll(), Times.Once);
        }

        [Fact]
        public async Task CreateAndDeleteAllPayments_Success()
        {
            // Arrange
            var payments = new List<Payment>
            {
                new Payment { Amount = 0, Date = DateTime.Now, Id = Guid.NewGuid() },
                new Payment { Amount = 0, Date = DateTime.Now, Id = Guid.NewGuid() }
            };

            _paymentRepositoryMock.Setup(x => x.Insert(It.IsAny<Payment>())).Returns(Task.FromResult(It.IsAny<Payment>()));
            _paymentRepositoryMock.Setup(x => x.DeleteAll()).Returns(Task.CompletedTask);


            foreach (var payment in payments)
            {
                 await _paymentRepositoryMock.Object.Insert(payment);
            }

            // Act
            var result = await _service.DeleteAllPayments();

            // Assert
            Assert.True(result.Success);
            _paymentRepositoryMock.Verify(x => x.Insert(It.IsAny<Payment>()), Times.Exactly(payments.Count));
            _paymentRepositoryMock.Verify(x => x.DeleteAll(), Times.Once);
        }
    }
}
