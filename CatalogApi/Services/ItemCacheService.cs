using CatalogApi.Data.Repositories;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Services;

public class ItemCacheService(ItemRepository repo, LookupRepository lookup)
{
    public IReadOnlyList<IdTextDto<byte>> ItemNames { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> ItemCategories { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> ItemTypes { get; private set; } = null!;
    public IReadOnlyList<ItemDto> Items { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> ItemDescriptions { get; private set; } = null!;

    public async Task LoadCacheAsync()
    {
        ItemNames = (await lookup.GetIdAndText<byte>(tableName:"item_names")).ToList();
        ItemCategories = (await lookup.GetIdAndText<byte>(tableName:"item_categories")).ToList();
        ItemTypes = (await lookup.GetIdAndText<byte>(tableName:"item_types")).ToList();
        Items = (await repo.GetItems()).ToList();
        ItemDescriptions = (await lookup.GetIdAndText<byte>(tableName:"item_descriptions", idColumn:"item_id", textColumn:"description")).ToList();
    }
}

