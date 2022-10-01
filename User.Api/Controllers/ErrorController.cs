using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace User.Api.Controllers;

public class ErrorController: ApiController
{
    [Route("/error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem(
            title: exception is null ? "unexpected exception" : exception.Message, 
            statusCode: StatusCodes.Status500InternalServerError);
    }
}