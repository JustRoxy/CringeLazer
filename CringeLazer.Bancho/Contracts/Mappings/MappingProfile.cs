using CringeLazer.Bancho.Contracts.Responses;
using CringeLazer.Core.Enums;
using CringeLazer.Core.Models.Statistics;
using Mapster;

namespace CringeLazer.Bancho.Contracts.Mappings;

public class MappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Countries, UserResponse.CountryResponse>()
            .Map(x => x.Code, x => x.ToString());

        config.NewConfig<IList<StatisticsModel>, StatisticsResponse>()
            .Map(x => x, x => x.First());
    }
}
