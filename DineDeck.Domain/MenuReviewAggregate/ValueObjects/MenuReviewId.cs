using DineDeck.Domain.Common.Models;

namespace DineDeck.Domain.MenuReviewAggregate.ValueObjects
{
    public sealed class MenuReviewId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuReviewId(Guid value)
        {
            Value = value;
        }

        public static MenuReviewId CreateUnique()
        {
            return new MenuReviewId(Guid.NewGuid());
        }

        public static MenuReviewId Create(Guid value)
        {
            return new MenuReviewId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}