using Mapster;
using RA.RockPaperScissors.API.Models;
using RA.RockPaperScissors.Domain.Entities.LeaderboardAggregate;
using RA.RockPaperScissors.Domain.Entities.PlayerAggregate;

namespace RA.RockPaperScissors.API.ApplicationStartup.Configuration;

public class MapsterConfigRegistration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        RegisterEnums(config);
        RegisterEntities(config);
    }

    private static void RegisterEnums(TypeAdapterConfig config)
    {
        config
            .NewConfig<Domain.Enums.RockPaperScissors, Models.Enums.RockPaperScissors>();
    }

    private static void RegisterEntities(TypeAdapterConfig config)
    {
        config
            .NewConfig<Player, PlayerDto>()
            .ConstructUsing(model => new PlayerDto(model.Id, model.Score, (Models.Enums.RockPaperScissors)(int)model.LastMove, model.IsHuman));

        config
            .NewConfig<PlayerDto, Player>()
            .ConstructUsing(model => Player.Create(model.Id, model.Score, (Domain.Enums.RockPaperScissors)(int)model.LastMove, model.IsHuman));

        config
            .NewConfig<Leaderboard, LeaderboardDto>()
            .ConstructUsing(model => new LeaderboardDto(model.Players.Adapt<IEnumerable<PlayerDto>>()));

        config
            .NewConfig<LeaderboardDto, Leaderboard>()
            .ConstructUsing(model => Leaderboard.Create(model.Players.Adapt<IEnumerable<Player>>()));
    }
}