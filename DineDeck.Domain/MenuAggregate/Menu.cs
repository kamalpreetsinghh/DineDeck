using DineDeck.Domain.Common.Models;
using DineDeck.Domain.Common.ValueObjects;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.HostAggregate.ValueObjects;
using DineDeck.Domain.MenuAggregate.Entities;
using DineDeck.Domain.MenuAggregate.ValueObjects;
using DineDeck.Domain.MenuReviewAggregate.ValueObjects;

namespace DineDeck.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _menuSections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }
    public IReadOnlyCollection<MenuSection> MenuSections => _menuSections.AsReadOnly();
    public HostId HostId { get; }
    public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyCollection<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        List<MenuSection>? menuSections,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        AverageRating = AverageRating.CreateNew();
        _menuSections = menuSections ?? new();
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        List<MenuSection>? menuSections)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            menuSections,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
