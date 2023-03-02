using DineDeck.Application.Common.Interfaces.Persistence;
using DineDeck.Domain.MenuAggregate;

namespace DineDeck.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly DineDeckDbContext _dbContext;

    public MenuRepository(DineDeckDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        try
        {
            _dbContext.Add(menu);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Could not save menu", ex);
        }
    }
}
