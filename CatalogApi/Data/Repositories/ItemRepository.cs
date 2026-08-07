using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Dapper;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Data.Repositories;

public class ItemRepository(IConfiguration config)
{
    public async Task<IEnumerable<ItemDto>> GetItems()
    {
        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = """
            SELECT
            id AS Id,
            item_name_id AS NameId,
            item_category_id AS CategoryId,
            item_type_id AS TypeId
            FROM items;
        """;
        return await conn.QueryAsync<ItemDto>(sql);
    }
}
