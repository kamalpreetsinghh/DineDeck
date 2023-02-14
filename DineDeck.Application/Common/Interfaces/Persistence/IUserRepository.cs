using DineDeck.Domain.Entities;

namespace DineDeck.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}