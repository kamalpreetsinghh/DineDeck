using DineDeck.Domain.Common.Models;
using DineDeck.Domain.Common.ValueObjects;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.GuestAggregate.ValueObjects;
using DineDeck.Domain.HostAggregate.ValueObjects;

namespace DineDeck.Domain.GuestAggregate.Entities;

public sealed class GuestRating : Entity<RatingId>
{
    public HostId HostId { get; private set; } = null!;
    public DinnerId DinnerId { get; private set; } = null!;
    public int Rating { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private GuestRating() { }

    private GuestRating(
        RatingId ratingId,
        HostId hostId,
        DinnerId dinnerId,
        int rating)
        : base(ratingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
    }

    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        int rating)
    {
        return new GuestRating(
            RatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating);
    }
}