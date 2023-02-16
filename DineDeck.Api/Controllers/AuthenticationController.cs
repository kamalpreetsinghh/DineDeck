using DineDeck.Application.Authentication.Common;
using DineDeck.Application.Common.Interfaces.Errors;
using DineDeck.Application.Services.Authentication.Command;
using DineDeck.Contracts.Authentication;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DineDeck.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _imediator;

    public AuthenticationController(IMediator imediator)
    {
        _imediator = imediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var registerCommand = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
            );

        Result<AuthenticationResult> registerResult = await _imediator.Send(registerCommand);

        if (registerResult.IsSuccess)
        {
            return Ok(MapAuthResult(registerResult.Value));
        }

        var firstError = registerResult.Errors[0];

        if (firstError is DuplicateEmailError)
        {
            return Problem(statusCode: StatusCodes.Status409Conflict, detail: "Email already exists");
        }

        return Problem();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var loginCommand = new LoginQuery(
            request.Email,
            request.Password
            );

        Result<AuthenticationResult> loginResult = await _imediator.Send(loginCommand);

        if (loginResult.IsSuccess)
        {
            return Ok(MapAuthResult(loginResult.Value));
        }


        return Problem();
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