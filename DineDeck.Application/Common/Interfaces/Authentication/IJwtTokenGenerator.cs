using DineDeck.Domain.Entities;

namespace DineDeck.Application.Common.Interfaces.Authentication;
public interface IJWTTokenGenerator
{
    string GenerateToken(User user);
}