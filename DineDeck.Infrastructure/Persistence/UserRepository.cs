using DineDeck.Application.Common.Interfaces.Persistence;
using DineDeck.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace DineDeck.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}
