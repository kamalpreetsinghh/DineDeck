using DineDeck.Domain.Common.Models;
using DineDeck.Domain.MenuAggregate.ValueObjects;

namespace DineDeck.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection() { }

    private MenuSection(
        string name,
        string description,
        List<MenuItem> items,
        MenuSectionId? menuSectionId = null)
        : base(menuSectionId ?? MenuSectionId.CreateUnique())
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem>? items = null)
    {
        return new MenuSection(name, description, items ?? new());
    }
}