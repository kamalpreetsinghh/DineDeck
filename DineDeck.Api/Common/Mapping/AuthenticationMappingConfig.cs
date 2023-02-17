using DineDeck.Application.Authentication.Common;
using DineDeck.Contracts.Authentication;
using Mapster;

namespace DineDeck.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    void IRegister.Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}