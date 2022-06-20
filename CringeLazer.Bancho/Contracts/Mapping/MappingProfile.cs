using Mapster;

namespace CringeLazer.Bancho.Contracts.Mapping;

public class MappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.User, int>()
            .Map(x => x, v => v.Id);
    }
}
