using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Dapper;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Data.Repositories;

public class BoundaryRepository(IConfiguration config)
{
    public async Task<IEnumerable<BoundaryDto>> GetBoundaries()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id as Id,
            character_id AS CharacterId,
            boundary_ascension_id AS AscensionId,
            boundary_type_id AS TypeId,
            improvement_value AS ImprovementValue,
            boundary_skill_name_id AS SkillNameId
            FROM boundaries;
        """;
        return await conn.QueryAsync<BoundaryDto>(sql);
    }
}

