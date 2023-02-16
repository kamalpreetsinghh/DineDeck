using DineDeck.Application.Common.Interfaces.Authentication;
using DineDeck.Application.Common.Interfaces.Errors;
using DineDeck.Application.Common.Interfaces.Persistence;
using DineDeck.Domain.Entities;
using OneOf;

namespace DineDeck.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJWTTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
            return new DuplicateEmailError();

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);
        if (user is null)
            throw new Exception("User not exists");

        if (user.Password != password)
            throw new Exception("Invalid password");

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}