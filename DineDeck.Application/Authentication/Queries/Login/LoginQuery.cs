using DineDeck.Application.Authentication.Common;
using FluentResults;
using MediatR;

namespace DineDeck.Application.Services.Authentication.Command;

public record LoginQuery(string Email, string Password) : IRequest<Result<AuthenticationResult>>;
