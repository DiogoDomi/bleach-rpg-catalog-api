using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Dapper;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Data.Repositories;

public class CoreStampRepository(IConfiguration config)
{
    public async Task<IEnumerable<CoreStampDto>> GetCoreStamps()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id AS Id,
            core_stamp_name_id AS NameId,
            exclusive_effect_character_id AS ExclusiveEffectCharacterId,
            rarity_id AS RarityId,
            star_rating_id AS StarRatingId,
            display_order AS DisplayOrder
            FROM core_stamps;
        """;
        return await conn.QueryAsync<CoreStampDto>(sql);
    }

    public async Task<IEnumerable<CoreStampBaseStatDto>> GetCoreStampBaseStats()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            core_stamp_id AS CoreStampId,
            stat_type_id AS StatTypeId,
            min_base_value AS MinBaseValue,
            max_base_value AS MaxBaseValue
            FROM core_stamp_base_stats;
        """;
        return await conn.QueryAsync<CoreStampBaseStatDto>(sql);
    }
}

