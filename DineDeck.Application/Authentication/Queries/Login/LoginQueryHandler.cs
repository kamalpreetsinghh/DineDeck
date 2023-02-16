using DineDeck.Application.Authentication.Common;
using DineDeck.Application.Common.Interfaces.Authentication;
using DineDeck.Application.Common.Interfaces.Errors;
using DineDeck.Application.Common.Interfaces.Persistence;
using FluentResults;
using MediatR;

namespace DineDeck.Application.Services.Authentication.Command
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IUserRepository userRepository, IJWTTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByEmail(query.Email);
            if (user is null)
                return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });

            if (user.Password != query.Password)
                return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}