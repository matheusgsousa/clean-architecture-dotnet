using clean_arch.Service.DTOs.Base;
using Microsoft.AspNetCore.Mvc;

namespace clean_arch.Api.Controllers.Extensions
{
    public static class ControllerExtension
    {
        public static ActionResult GetResponse<T>(this ControllerBase controller, Service.DTOs.Base.ResultResponse<T> response) where T : class
        {
            if (response.Success)
                return controller.Ok(response);
            else
            {
                return response.Error.Type switch
                {
                    ResponseErrorType.BadRequest => controller.BadRequest(response),
                    ResponseErrorType.InternalError => controller.StatusCode(StatusCodes.Status500InternalServerError, response),
                    ResponseErrorType.NotFound => controller.StatusCode(StatusCodes.Status404NotFound, response),
                    ResponseErrorType.Forbidden => controller.StatusCode(StatusCodes.Status403Forbidden, response),
                    ResponseErrorType.Created => controller.StatusCode(StatusCodes.Status201Created, response),
                    ResponseErrorType.UnprocessableEntity => controller.StatusCode(StatusCodes.Status422UnprocessableEntity, response),
                    _ => throw new NotImplementedException(),
                };
            }
        }
    }
}
