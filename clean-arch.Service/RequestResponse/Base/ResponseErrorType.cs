using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_arch.Service.DTOs.Base
{
    public enum ResponseErrorType
    {
        Success = 200,
        Created = 201,
        BadRequest = 400,
        UnprocessableEntity = 422,
        Forbidden = 403,
        NotFound = 404,
        InternalError = 500
    }
}
