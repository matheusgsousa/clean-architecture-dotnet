using clean_arch.Service.DTOs.Base;
using clean_arch.Service.RequestResponse.Request;
using clean_arch.Service.RequestResponse.Response;


namespace clean_arch.Service.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<ResultResponse<PaymentResponse>> Submit(PaymentRequest request);
    }
}
