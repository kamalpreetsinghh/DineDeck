using DineDeck.Domain.BillAggregate.ValueObjects;
using DineDeck.Domain.Common.Models;
using DineDeck.Domain.DinnerAggregate.Enums;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.GuestAggregate.ValueObjects;
using DineDeck.Domain.MenuAggregate.ValueObjects;

namespace DineDeck.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public DinnerId DinnerId { get; private set; } = null!;
    public GuestId GuestId { get; private set; } = null!;
    public BillId BillId { get; private set; } = null!;
    public int NumberOfGuests { get; private set; }
    public ReservationStatus Status { get; private set; }
    public DateTime ArrivalDateTime { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Reservation() { }

    private Reservation(
        ReservationId reservationId,
        DinnerId dinnerId,
        GuestId guestId,
        BillId billId,
        int numberOfGuests,
        ReservationStatus status,
        DateTime arrivalDateTime)
        : base(reservationId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        BillId = billId;
        NumberOfGuests = numberOfGuests;
        Status = status;
        ArrivalDateTime = arrivalDateTime;
    }

    public static Reservation Create(
        DinnerId dinnerId,
        GuestId guestId,
        BillId billId,
        int numberOfGuests,
        ReservationStatus status,
        DateTime arrivalDateTime)
    {
        return new(
            ReservationId.CreateUnique(),
            dinnerId,
            guestId,
            billId,
            numberOfGuests,
            status,
            arrivalDateTime
        );
    }
}
