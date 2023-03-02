using DineDeck.Domain.BillAggregate.ValueObjects;
using DineDeck.Domain.Common.Models;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.GuestAggregate.Entities;
using DineDeck.Domain.GuestAggregate.ValueObjects;
using DineDeck.Domain.MenuReviewAggregate.ValueObjects;
using DineDeck.Domain.UserAggregate.ValueObjects;

namespace DineDeck.Domain.GuestAggregate;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<GuestRating> _guestRatings = new();
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string ProfileImage { get; private set; } = null!;
    public UserId UserId { get; private set; } = null!;
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<GuestRating> GuestRatings => _guestRatings.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Guest() { }

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
        : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId);
    }
}