using DineDeck.Domain.Common.Models;
using DineDeck.Domain.Common.ValueObjects;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.HostAggregate.ValueObjects;
using DineDeck.Domain.MenuAggregate.ValueObjects;
using DineDeck.Domain.UserAggregate.ValueObjects;

namespace DineDeck.Domain.HostAggregate;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string ProfileImage { get; private set; } = null!;
    public AverageRating AverageRating { get; private set; } = null!;
    public UserId UserId { get; private set; } = null!;
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    private Host() { }

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId)
        : base(hostId ?? HostId.Create(userId.Value))
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new(
            HostId.Create(userId.Value),
            firstName,
            lastName,
            profileImage,
            AverageRating.CreateNew(),
            userId);
    }
}