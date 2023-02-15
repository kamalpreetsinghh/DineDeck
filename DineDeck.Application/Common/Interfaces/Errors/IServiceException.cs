using System.Net;

namespace DineDeck.Application.Common.Interfaces.Errors;
public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}