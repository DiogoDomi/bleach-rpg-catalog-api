using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Dapper;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Data.Repositories;

public class GameConfigRepository(IConfiguration config)
{
    public async Task<IEnumerable<CharacterMaxUpgradeCostDto>> GetCharacterMaxUpgradeCosts()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id AS Id,
            rarity_id AS RarityId,
            character_role_id AS CharacterRoleId,
            character_affinity_id AS CharacterAffinityId,
            item_id AS ItemId,
            amount AS Amount
            FROM character_max_upgrade_costs;
        """;
        return await conn.QueryAsync<CharacterMaxUpgradeCostDto>(sql);
    }

    public async Task<IEnumerable<LimitedGachaGuaranteedPullCostDto>> GetLimitedGachaGuaranteedPullCosts()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            entity_type_id AS EntityTypeId,
            item_id AS ItemId,
            amount AS Amount
            FROM limited_gacha_guaranteed_pull_costs;
        """;
        return await conn.QueryAsync<LimitedGachaGuaranteedPullCostDto>(sql);
    }

    public async Task<IEnumerable<GameLevelConfigDto>> GetGameLevelConfigs()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id AS Id,
            entity_type_id AS EntityTypeId,
            rarity_id AS RarityId,
            star_rating_id AS StarRatingId,
            skill_subcategory_id AS SkillSubCategoryId,
            min_level AS MinLevel,
            max_level AS MaxLevel,
            min_ascension_level AS MinAscensionLevel,
            max_ascension_level AS MaxAscensionLevel
            FROM game_level_configs;
        """;
        return await conn.QueryAsync<GameLevelConfigDto>(sql);
    }
}

