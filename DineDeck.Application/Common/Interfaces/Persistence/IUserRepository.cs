using DineDeck.Domain.UserAggregate;

namespace DineDeck.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}