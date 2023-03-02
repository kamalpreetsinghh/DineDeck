using DineDeck.Application.Authentication.Common;
using DineDeck.Application.Services.Authentication.Command;
using DineDeck.Contracts.Authentication;
using Mapster;

namespace DineDeck.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    void IRegister.Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>()
            .Map(dest => dest, src => src);

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest.Id, src => src.User.Id.Value.ToString())
            .Map(dest => dest.Email, src => src.User.Email)
            .Map(dest => dest.FirstName, src => src.User.FirstName)
            .Map(dest => dest.LastName, src => src.User.LastName);
    }
}