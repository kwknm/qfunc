using Mapster;
using QFunc.Application.Identity.Common;
using QFunc.Contracts.Identity;

namespace QFunc.Api.Common.Mapping;

public class IdentityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<IdentityResult, IdentityResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}