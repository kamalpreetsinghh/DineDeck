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
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public double AverageRating { get; private set; }
    public int NumRatings { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; private set; } = null!;
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        List<MenuSection> sections)
        : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = sections;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        List<MenuSection>? sections = null)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            sections ?? new());
    }

    private Menu() { }
}
