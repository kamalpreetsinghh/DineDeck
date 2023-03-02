using DineDeck.Domain.Common.Models;
using DineDeck.Domain.Common.ValueObjects;
using DineDeck.Domain.DinnerAggregate.Entities;
using DineDeck.Domain.DinnerAggregate.Enums;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.HostAggregate.ValueObjects;
using DineDeck.Domain.MenuAggregate.ValueObjects;

namespace DineDeck.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DinnerStatus Status { get; private set; }
    public bool IsPublic { get; private set; }
    public int MaxGuests { get; private set; }
    public Price Price { get; private set; } = null!;
    public HostId HostId { get; private set; } = null!;
    public MenuId MenuId { get; private set; } = null!;
    public string ImageUrl { get; private set; } = null!;
    public Location Location { get; private set; } = null!;
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Dinner() { }

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
        : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
    }
    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location);
    }
}
