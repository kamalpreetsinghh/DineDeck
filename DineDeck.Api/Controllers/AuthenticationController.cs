using DineDeck.Application.Authentication.Common;
using DineDeck.Application.Common.Interfaces.Errors;
using DineDeck.Application.Services.Authentication.Command;
using DineDeck.Contracts.Authentication;
using FluentResults;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DineDeck.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _imediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator imediator, IMapper mapper)
    {
        _imediator = imediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var registerCommand = _mapper.Map<RegisterCommand>(request);

        Result<AuthenticationResult> registerResult = await _imediator.Send(registerCommand);

        if (registerResult.IsSuccess)
        {
            return Ok(_mapper.Map<AuthenticationResponse>(registerResult.Value));
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
        var loginQuery = _mapper.Map<LoginQuery>(request);

        Result<AuthenticationResult> loginResult = await _imediator.Send(loginQuery);

        if (loginResult.IsSuccess)
        {
            return Ok(_mapper.Map<AuthenticationResponse>(loginResult.Value));
        }

        return Problem();
    }

}