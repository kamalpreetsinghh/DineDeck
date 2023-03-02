using DineDeck.Domain.BillAggregate.ValueObjects;
using DineDeck.Domain.Common.Models;
using DineDeck.Domain.Common.ValueObjects;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.GuestAggregate.ValueObjects;
using DineDeck.Domain.HostAggregate.ValueObjects;

namespace DineDeck.Domain.BillAggregate;

public sealed class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; private set; } = null!;
    public GuestId GuestId { get; private set; } = null!;
    public HostId HostId { get; private set; } = null!;
    public Price Price { get; private set; } = null!;
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Bill() { }

    private Bill(
        BillId billId,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price)
        : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
    }

    public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price)
    {
        return new Bill(
            BillId.CreateUnique(),
            dinnerId,
            guestId,
            hostId,
            price
        );
    }
}