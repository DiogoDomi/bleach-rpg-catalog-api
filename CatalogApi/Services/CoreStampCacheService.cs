using CatalogApi.Data.Repositories;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Services;

public class CoreStampCacheService(CoreStampRepository repo, LookupRepository lookup)
{
    public IReadOnlyList<IdTextDto<ushort>> CoreStampNames { get; private set; } = null!;
    public IReadOnlyList<CoreStampDto> CoreStamps { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<ushort>> CoreStampTemplates { get; private set; } = null!;
    public IReadOnlyList<CoreStampBaseStatDto> CoreStampBaseStats { get; private set; } = null!;

    public async Task LoadCacheAsync()
    {
        CoreStampNames = (await lookup.GetIdAndText<ushort>(tableName:"core_stamp_names")).ToList();
        CoreStamps = (await repo.GetCoreStamps()).ToList();
        CoreStampTemplates = (await lookup.GetIdAndText<ushort>(tableName:"core_stamp_templates", idColumn:"core_stamp_id", textColumn:"template")).ToList();
        CoreStampBaseStats = (await repo.GetCoreStampBaseStats()).ToList();
    }
}

