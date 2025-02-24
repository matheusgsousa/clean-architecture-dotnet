using clean_arch.Domain.DTOs;
using clean_arch.Domain.Entities;
using clean_arch.Persistence.Repositories.Interfaces;
using clean_arch.Service.DTOs.Base;
using clean_arch.Service.RequestResponse.Request;
using clean_arch.Service.RequestResponse.Response;
using clean_arch.Service.Services.Interfaces;

namespace clean_arch.Service.Services
{
    public class PaymentService(IPaymentRepository paymentRepository) : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository = paymentRepository;
        public async Task<ResultResponse<PaymentResponse>>Submit(PaymentRequest request)
        {
            var response = new ResultResponse<PaymentResponse>();
            try
            {
                var payment = new Payment()
                {
                    Amount = request.Amount,
                    Date = request.Date
                };

                payment = await _paymentRepository.Insert(payment);

                var paymentDTO = new PaymentDTO()
                {
                    Id = payment.Id,
                    Amount = payment.Amount,
                    Date = payment.Date
                };
                var responseData = new PaymentResponse()
                {
                    PaymentDTO = paymentDTO
                };

                response.AddData(responseData);

                return response;
            }catch (Exception ex)
            {
                response.AddError(ex, "Error in submit payment");
                return response;
            };
        }

        public async Task<ResultResponse<object>> DeleteAllPayments()
        {
            var response = new ResultResponse<object>();
            try
            {
                await _paymentRepository.DeleteAll();
                return response;
            }
            catch (Exception ex)
            {
                response.AddError(ex, "Error in delete all payments");
                return response;
            }
        }
        public async Task<ResultResponse<PaymentStatsResponse>> GetPaymentsStats()
        {
            var response = new ResultResponse<PaymentStatsResponse>();
            try
            {
                var payments =  _paymentRepository.GetAll();
                var totalAmount = payments.Sum(x => x.Amount);
                var averageAmount = totalAmount / payments.Count();
                var paymentStats = new PaymentStatsResponse()
                {
                    TotalAmount = totalAmount,
                    AverageAmount = averageAmount,
                    TotalPayments = payments.Count(),
                    MinAmount = payments.Min(x => x.Amount),
                    MaxAmount = payments.Max(x => x.Amount)
                };
                response.AddData(paymentStats);
                return response;
            }
            catch (Exception ex)
            {
                response.AddError(ex, "Error in get payment stats");
                return response;
            }
        }
    }
}
