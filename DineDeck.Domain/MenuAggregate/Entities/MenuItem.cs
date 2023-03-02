using DineDeck.Domain.Common.Models;
using DineDeck.Domain.MenuAggregate.ValueObjects;

namespace DineDeck.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;

    private MenuItem() { }

    private MenuItem(string name, string description)
        : base(MenuItemId.CreateUnique())
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(name, description);
    }
}