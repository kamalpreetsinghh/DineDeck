using DineDeck.Domain.Common.Models;

namespace DineDeck.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public Guid Value { get; }

    public DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}