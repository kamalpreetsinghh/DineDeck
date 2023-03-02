using DineDeck.Domain.Common.Models;

namespace DineDeck.Domain.Common.ValueObjects;

public sealed class Price : ValueObject
{
    public double Amount { get; private set; }
    public string Currency { get; private set; } = null!;

    private Price() { }

    private Price(double amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price Create(double amount, string currency)
    {
        return new Price(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
