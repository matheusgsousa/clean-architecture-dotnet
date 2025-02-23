using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_arch.Service.DTOs.Base
{
    public class ResponseError
    {
        public ResponseError(ResponseErrorType type, string customMessage, string internalError = null)
        {
            Type = type;
            CustomMessage = customMessage;
            InternalError = internalError;
        }

        public ResponseErrorType Type { get; set; }
        public string CustomMessage { get; set; }
        public string InternalError { get; set; }
    }
}
