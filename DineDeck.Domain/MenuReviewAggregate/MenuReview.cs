using DineDeck.Domain.Common.Models;
using DineDeck.Domain.Common.ValueObjects;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.GuestAggregate.ValueObjects;
using DineDeck.Domain.HostAggregate.ValueObjects;
using DineDeck.Domain.MenuAggregate.ValueObjects;
using DineDeck.Domain.MenuReviewAggregate.ValueObjects;

namespace DineDeck.Domain.MenuReviewAggregate;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public int Rating { get; private set; }
    public string Comment { get; private set; } = null!;
    public HostId HostId { get; private set; } = null!;
    public MenuId MenuId { get; private set; } = null!;
    public GuestId GuestId { get; private set; } = null!;
    public DinnerId DinnerId { get; private set; } = null!;
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private MenuReview() { }

    private MenuReview(
        MenuReviewId menuReviewId,
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
        : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
    }

    public static MenuReview Create(
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
    {
        return new MenuReview(
            MenuReviewId.CreateUnique(),
            rating,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId);
    }
}