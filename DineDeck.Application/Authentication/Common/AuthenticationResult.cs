using DineDeck.Domain.UserAggregate;

namespace DineDeck.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);