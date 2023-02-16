using DineDeck.Application.Common.Interfaces.Errors;
using DineDeck.Application.Services.Authentication;
using DineDeck.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace DineDeck.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        OneOf<AuthenticationResult, DuplicateEmailError> registerResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
            );

        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            error => Problem(statusCode: (int)error.StatusCode, title: error.ErrorMessage)
            );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
            request.Email,
            request.Password
            );
        AuthenticationResponse authResponse = MapAuthResult(authResult);
        return Ok(authResponse);
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                    authResult.User.Id,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token
                    );
    }
}