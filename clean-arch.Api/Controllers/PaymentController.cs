using clean_arch.Api.Controllers.Extensions;
using clean_arch.Service.RequestResponse.Request;
using clean_arch.Service.RequestResponse.Response;
using clean_arch.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clean_arch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController(IPaymentService paymentService) : ControllerBase
    {

        private readonly IPaymentService _paymentService = paymentService;
    

        [HttpPost]
        public async Task<ActionResult<ResultResponse<PaymentResponse>>>Submit(PaymentRequest request)
        {
            var result = await _paymentService.Submit(request);
            return this.GetResponse(result);

        }
    }
}
