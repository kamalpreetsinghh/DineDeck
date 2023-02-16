using DineDeck.Application.Common.Interfaces.Errors;
using OneOf;

namespace DineDeck.Application.Services.Authentication;

public interface IAuthenticationService
{
    public OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName, string lastName, string email, string password);

    public AuthenticationResult Login(string email, string password);
}