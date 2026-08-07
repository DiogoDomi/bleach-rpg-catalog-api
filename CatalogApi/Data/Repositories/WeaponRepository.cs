using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Dapper;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Data.Repositories;

public class WeaponRepository(IConfiguration config)
{
    public async Task<IEnumerable<WeaponDto>> GetWeapons()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            character_id AS CharacterId,
            weapon_name_id AS NameId,
            weapon_type_id AS TypeId,
            rarity_id AS RarityId
            FROM weapons;
        """;
        return await conn.QueryAsync<WeaponDto>(sql);
    }

    public async Task<IEnumerable<WeaponBaseStatDto>> GetWeaponBaseStats()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            character_id AS CharacterId,
            stat_type_id AS StatTypeId,
            min_base_value AS MinBaseValue,
            max_base_value AS MaxBaseValue
            FROM weapon_base_stats;
        """;
        return await conn.QueryAsync<WeaponBaseStatDto>(sql);
    }
}

