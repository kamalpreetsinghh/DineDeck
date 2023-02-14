using DineDeck.Domain.Entities;

namespace DineDeck.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);