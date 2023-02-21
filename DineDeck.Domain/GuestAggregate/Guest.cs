using DineDeck.Domain.BillAggregate.ValueObjects;
using DineDeck.Domain.Common.Models;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.GuestAggregate.ValueObjects;
using DineDeck.Domain.MenuReviewAggregate.ValueObjects;
using DineDeck.Domain.UserAggregate.ValueObjects;

namespace DineDeck.Domain.GuestAggregate;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcominDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyCollection<DinnerId> UpcomingDinnerIds => _upcominDinnerIds.AsReadOnly();
    public IReadOnlyCollection<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyCollection<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyCollection<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyCollection<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
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
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}