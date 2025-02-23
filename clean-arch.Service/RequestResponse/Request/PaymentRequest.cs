using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace clean_arch.Service.RequestResponse.Request
{
    public class PaymentRequest
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
