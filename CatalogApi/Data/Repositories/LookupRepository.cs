using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Dapper;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Data.Repositories;

public class LookupRepository(IConfiguration config)
{
    public async Task<IEnumerable<IdTextDto<T>>> GetIdAndText<T>(string tableName, string idColumn = "id", string textColumn = "name")
    {
        if (!Regex.IsMatch(tableName, @"^[a-z_]+$"))
        {
            throw new ArgumentException("Invalid table name.", nameof(tableName));
        }

        using var conn = new SqliteConnection(config.GetConnectionString("bsr_data"));
        var sql = $"""
            SELECT {idColumn} AS Id,
            {textColumn} AS Text
            FROM {tableName};
        """;
        return await conn.QueryAsync<IdTextDto<T>>(sql);
    }
}

