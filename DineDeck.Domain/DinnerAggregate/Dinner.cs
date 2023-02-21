using DineDeck.Domain.Common.Models;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.HostAggregate.ValueObjects;

namespace DineDeck.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    public DinnerId DinnerId { get; }
    public HostId HostId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    private Dinner(
        DinnerId dinnerId,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(dinnerId)
    {
        DinnerId = dinnerId;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    public static Dinner Create(
        HostId hostId
    )
    {
        return new(
            DinnerId.CreateUnique(),
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
