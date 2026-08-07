using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Dapper;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Data.Repositories;

public class SetStampRepository(IConfiguration config)
{
    public async Task<IEnumerable<SetStampDto>> GetSetStamps()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id AS Id,
            set_stamp_name_id AS NameId,
            display_order AS DisplayOrder
            FROM set_stamps;
        """;
        return await conn.QueryAsync<SetStampDto>(sql);
    }

    public async Task<IEnumerable<SetStampPassiveDto>> GetSetStampPassives()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id AS Id,
            set_stamp_passive_name_id AS NameId,
            passive_level AS PassiveLevel
            FROM set_stamp_passives;
        """;
        return await conn.QueryAsync<SetStampPassiveDto>(sql);
    }

    public async Task<IEnumerable<SetStampLevelGapDto>> GetSetStampLevelGaps()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            star_rating_id AS StarRatingId,
            ascension_level AS AscensionLevel,
            max_enhance_level AS MaxEnhanceLevel
            FROM set_stamp_level_gaps;
        """;
        return await conn.QueryAsync<SetStampLevelGapDto>(sql);
    }

    public async Task<IEnumerable<SetStampFixedBasicStatDto>> GetSetStampFixedBasicStats()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            piece_index AS PieceIndex,
            stat_type_id AS StatTypeId
            FROM set_stamp_fixed_basic_stats;
        """;
        return await conn.QueryAsync<SetStampFixedBasicStatDto>(sql);
    }

    public async Task<IEnumerable<SetStampPoolBasicStatDto>> GetSetStampPoolBasicStats()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            piece_index AS PieceIndex,
            stat_type_id AS StatTypeId
            FROM set_stamp_pool_basic_stats;
        """;
        return await conn.QueryAsync<SetStampPoolBasicStatDto>(sql);
    }

    public async Task<IEnumerable<SetStampFixedBasicStatGrowthDto>> GetSetStampFixedBasicStatGrowths()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            piece_index AS PieceIndex,
            star_rating_id AS StarRatingId,
            min_base_value AS MinBaseValue,
            max_base_value AS MaxBaseValue
            FROM set_stamp_fixed_basic_stat_growths;
        """;
        return await conn.QueryAsync<SetStampFixedBasicStatGrowthDto>(sql);
    }

    public async Task<IEnumerable<SetStampPoolBasicStatGrowthDto>> GetSetStampPoolBasicStatGrowths()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            star_rating_id AS StarRatingId,
            stat_type_id AS StatTypeId,
            min_base_value AS MinBaseValue,
            max_base_value AS MaxBaseValue
            FROM set_stamp_pool_basic_stat_growths;
        """;
        return await conn.QueryAsync<SetStampPoolBasicStatGrowthDto>(sql);
    }

    public async Task<IEnumerable<SetStampPoolAdvancedStatGrowthDto>> GetSetStampPoolAdvancedStatGrowths()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            star_rating_id AS StarRatingId,
            stat_type_id AS StatTypeId,
            min_base_value AS MinBaseValue,
            max_base_value AS MaxBaseValue
            FROM set_stamp_pool_advanced_stat_growths;
        """;
        return await conn.QueryAsync<SetStampPoolAdvancedStatGrowthDto>(sql);
    }
}

