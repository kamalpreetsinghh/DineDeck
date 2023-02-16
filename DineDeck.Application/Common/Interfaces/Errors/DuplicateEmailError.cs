using System.Net;
using FluentResults;

namespace DineDeck.Application.Common.Interfaces.Errors;
public class DuplicateEmailError : IError
{
    List<IError> IError.Reasons => throw new NotImplementedException();

    string IReason.Message => throw new NotImplementedException();

    Dictionary<string, object> IReason.Metadata => throw new NotImplementedException();
}