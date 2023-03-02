using DineDeck.Domain.Common.Models;
using DineDeck.Domain.UserAggregate.ValueObjects;

namespace DineDeck.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private User() { }

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password)
        : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password
    )
    {
        return new User(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password);
    }
}