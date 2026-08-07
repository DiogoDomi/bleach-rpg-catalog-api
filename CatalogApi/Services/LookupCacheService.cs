using CatalogApi.Data.Repositories;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Services;

public class LookupCacheService(LookupRepository repo)
{
    public IReadOnlyList<IdTextDto<byte>> Rarities { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> StatTypes { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> StarRatings { get; private set; } = null!;

    public async Task LoadCacheAsync()
    {
        Rarities = (await repo.GetIdAndText<byte>(tableName:"rarities")).ToList();
        StatTypes = (await repo.GetIdAndText<byte>(tableName:"stat_types")).ToList();
        StarRatings = (await repo.GetIdAndText<byte>(tableName:"star_ratings")).ToList();
    }
}

