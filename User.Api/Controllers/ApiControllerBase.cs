using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using User.Api.Common.Http;
using User.Domain.Common.Errors;

namespace User.Api.Controllers;

[ApiController]
[Authorize]
public abstract class ApiControllerBase: ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
        {
            return Problem();
        }
        
        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            ValidationProblem(errors);
        }
        
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        var firstError = errors[0];
        return Problem(firstError);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.NumericType switch
        {
            (int)ErrorType.Conflict => StatusCodes.Status409Conflict,
            (int)ErrorType.Validation => StatusCodes.Status400BadRequest,
            (int)ErrorType.NotFound => StatusCodes.Status404NotFound,
            NumericErrorTypes.Unauthorized => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };
            
        return Problem(statusCode: statusCode, title: error.Description);
    }
    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(
                error.Code, 
                error.Description);
        }
        
        return ValidationProblem(modelStateDictionary);
    }
}