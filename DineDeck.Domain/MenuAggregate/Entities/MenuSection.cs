using DineDeck.Domain.Common.Models;
using DineDeck.Domain.MenuAggregate.ValueObjects;

namespace DineDeck.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _menuItems = new();
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyCollection<MenuItem> MenuItems => _menuItems.AsReadOnly();

    public MenuSection(MenuSectionId menuSectionId, string name, string description) : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    public MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuItem> menuItems) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _menuItems = menuItems;
    }

    public static MenuSection Create(string name, string description)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }

    public static MenuSection Create(string name, string description, List<MenuItem> menuItems)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }
}