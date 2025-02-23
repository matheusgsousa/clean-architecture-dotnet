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

    }
}
