using DineDeck.Application.Common.Interfaces.Errors;
using FluentResults;

namespace DineDeck.Application.Services.Authentication;

public interface IAuthenticationService
{
    public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

    public AuthenticationResult Login(string email, string password);
}