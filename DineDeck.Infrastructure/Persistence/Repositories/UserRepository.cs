using DineDeck.Application.Common.Interfaces.Persistence;
using DineDeck.Domain.UserAggregate;

namespace DineDeck.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DineDeckDbContext _dbContext;

    public UserRepository(DineDeckDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Email == email);
    }

    public void Add(User user)
    {
        try
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not save menu", ex);
        }
    }
}
