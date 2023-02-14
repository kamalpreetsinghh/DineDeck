using DineDeck.Application.Common.Interfaces.Services;

namespace DineDeck.Infrastructure.Services;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}