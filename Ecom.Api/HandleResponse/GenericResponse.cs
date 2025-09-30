using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Ecom.Api.HandleResponse
{
    public static class GenericResponse
    {
        public static ActionResult handleResponse(this ControllerBase _controller , int StatusCode , string? Message = null)
        {
            if(Message is  null)
            {
                Message = StatusCode switch
                {
                    200 => "Done",
                    400 => "BadRequest",
                    401 => "UnAuthorized",
                    403 => "Not Allwoed",
                    500 => "Server Error",
                    _ => null,
                };
            }
            if(StatusCode == 200)
                return _controller.Ok(Message);
            else
                return _controller.BadRequest(Message);

        }

    }
}
