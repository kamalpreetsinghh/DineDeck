using DineDeck.Application.Authentication.Common;
using DineDeck.Application.Common.Interfaces.Authentication;
using DineDeck.Application.Common.Interfaces.Errors;
using DineDeck.Application.Common.Interfaces.Persistence;
using DineDeck.Domain.Entities;
using FluentResults;
using MediatR;

namespace DineDeck.Application.Services.Authentication.Command;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
{
    private readonly IJWTTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<Result<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not null)
            return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });

        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}