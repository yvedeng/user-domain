using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using User.Api.Common.Http;
using User.Domain.Common.Errors;

namespace User.Api.Controllers;

[ApiController]
public class ApiController: ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        var firstError = errors[0];
        var statusCode = firstError.NumericType switch
        {
            (int)ErrorType.Conflict => StatusCodes.Status409Conflict,
            (int)ErrorType.Validation => StatusCodes.Status400BadRequest,
            (int)ErrorType.NotFound => StatusCodes.Status404NotFound,
            NumericErrorTypes.Unauthorized => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };
            
        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}