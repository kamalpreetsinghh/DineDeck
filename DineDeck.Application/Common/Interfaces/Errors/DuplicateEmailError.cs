using System.Net;

namespace DineDeck.Application.Common.Interfaces.Errors;
public record struct DuplicateEmailError()
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already exists";
}