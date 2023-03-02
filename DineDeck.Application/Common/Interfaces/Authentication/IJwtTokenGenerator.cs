using DineDeck.Domain.UserAggregate;

namespace DineDeck.Application.Common.Interfaces.Authentication;
public interface IJWTTokenGenerator
{
    string GenerateToken(User user);
}