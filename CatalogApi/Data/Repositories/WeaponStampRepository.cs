using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Dapper;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Data.Repositories;

public class WeaponStampRepository(IConfiguration config)
{
    public async Task<IEnumerable<WeaponStampDto>> GetWeaponStamps()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id AS Id,
            weapon_stamp_name_id AS NameId,
            exclusive_effect_character_id AS ExclusiveEffectCharacterId,
            rarity_id AS RarityId,
            stats_multiplier_value AS StatsMultiplierValue,
            display_order AS DisplayOrder
            FROM weapon_stamps;
        """;
        return await conn.QueryAsync<WeaponStampDto>(sql);
    }
}

