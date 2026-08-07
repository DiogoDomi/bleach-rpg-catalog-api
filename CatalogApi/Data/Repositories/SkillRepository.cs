using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Dapper;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Data.Repositories;

public class SkillRepository(IConfiguration config)
{
    public async Task<IEnumerable<SkillCategoryDto>> GetSkillCategories()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id AS Id,
            name AS Name,
            display_order AS DisplayOrder
            FROM skill_categories;
        """;
        return await conn.QueryAsync<SkillCategoryDto>(sql);
    }

    public async Task<IEnumerable<SkillSubCategoryDto>> GetSkillSubCategories()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id AS Id,
            name AS Name,
            skill_category_id AS SkillCategoryId,
            display_order AS DisplayOrder
            FROM skill_subcategories;
        """;
        return await conn.QueryAsync<SkillSubCategoryDto>(sql);
    }

    public async Task<IEnumerable<SkillDto>> GetSkills()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id as Id,
            character_id AS CharacterId,
            skill_name_id AS NameId,
            skill_subcategory_id AS SubCategoryId,
            display_order AS DisplayOrder
            FROM skills;
        """;
        return await conn.QueryAsync<SkillDto>(sql);
    }

    public async Task<IEnumerable<SkillTagMappingDto>> GetSkillTagMapping()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            skill_id AS Id,
            skill_tag_id AS TagId
            FROM skill_tag_mapping;
        """;
        return await conn.QueryAsync<SkillTagMappingDto>(sql);
    }
}

