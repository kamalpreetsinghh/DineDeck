using DineDeck.Domain.Common.Models;

namespace DineDeck.Domain.BillAggregate.ValueObjects;

public sealed class BillId : ValueObject
{
    public Guid Value { get; private set; }

    private BillId(Guid value) => Value = value;

    public static BillId CreateUnique()
    {
        return new BillId(Guid.NewGuid());
    }

    public static BillId Create(Guid value)
    {
        return new BillId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
