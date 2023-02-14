namespace DineDeck.Application.Common.Interfaces.Authentication;
public interface IJWTTokenGenerator
{
    string GenerateToken(Guid userId, string FirstName, string lastName);
}