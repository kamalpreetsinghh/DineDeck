using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DineDeck.Api.Controllers;

[ApiController]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Problem(
            title: exception?.Message,
            detail: exception?.StackTrace,
            statusCode: StatusCodes.Status500InternalServerError);
    }
}