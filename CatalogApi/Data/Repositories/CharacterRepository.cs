using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Dapper;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Data.Repositories;

public class CharacterRepository(IConfiguration config)
{
    public async Task<IEnumerable<CharacterRoleDto>> GetCharacterRoles()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id AS Id,
            name AS Name,
            description AS Description
            FROM character_roles;
        """;
        return await conn.QueryAsync<CharacterRoleDto>(sql);
    }

    public async Task<IEnumerable<CharacterDto>> GetCharacters()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id AS Id,
            character_name_id AS NameId,
            character_affinity_id AS AffinityId,
            character_role_id AS RoleId,
            character_faction_id AS FactionId,
            rarity_id AS RarityId,
            display_order AS DisplayOrder
            FROM characters;
        """;
        return await conn.QueryAsync<CharacterDto>(sql);
    }

    public async Task<IEnumerable<CharacterBaseStatDto>> GetCharacterBaseStats()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            character_id AS CharacterId,
            stat_type_id AS StatTypeId,
            min_base_value AS MinBaseValue,
            max_base_value AS MaxBaseValue
            FROM character_base_stats;
        """;
        return await conn.QueryAsync<CharacterBaseStatDto>(sql);
    }
}

