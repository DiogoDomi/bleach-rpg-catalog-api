using CatalogApi.Data.Repositories;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Services;

public class GameConfigCacheService(GameConfigRepository repo, LookupRepository lookup)
{
    public IReadOnlyList<CharacterMaxUpgradeCostDto> CharacterMaxUpgradeCosts { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> EntityTypes { get; private set; } = null!;
    public IReadOnlyList<LimitedGachaGuaranteedPullCostDto> LimitedGachaGuaranteedPullCosts { get; private set; } = null!;
    public IReadOnlyList<GameLevelConfigDto> GameLevelConfigs { get; private set; } = null!;

    public async Task LoadCacheAsync()
    {
        CharacterMaxUpgradeCosts = (await repo.GetCharacterMaxUpgradeCosts()).ToList();
        EntityTypes = (await lookup.GetIdAndText<byte>(tableName:"entity_types")).ToList();
        LimitedGachaGuaranteedPullCosts = (await repo.GetLimitedGachaGuaranteedPullCosts()).ToList();
        GameLevelConfigs = (await repo.GetGameLevelConfigs()).ToList();
    }
}


