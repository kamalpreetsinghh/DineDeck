using DineDeck.Application.Common.Interfaces.Persistence;
using DineDeck.Domain.MenuAggregate;

namespace DineDeck.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = new();

    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}
