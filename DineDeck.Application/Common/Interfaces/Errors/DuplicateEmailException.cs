using System.Net;

namespace DineDeck.Application.Common.Interfaces.Errors
{
    public class DuplicateEmailException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Error: Email already exists.";
    }
}