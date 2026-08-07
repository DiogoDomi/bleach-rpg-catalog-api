using CatalogApi.Data.Repositories;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Services;

public class SetStampCacheService(SetStampRepository repo, LookupRepository lookup)
{
    public IReadOnlyList<IdTextDto<ushort>> SetStampNames { get; private set; } = null!;
    public IReadOnlyList<SetStampDto> SetStamps { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<ushort>> SetStampTemplates { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> SetStampPassiveNames { get; private set; } = null!;
    public IReadOnlyList<SetStampPassiveDto> SetStampPassives { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> SetStampPassiveTemplates { get; private set; } = null!;
    public IReadOnlyList<SetStampLevelGapDto> SetStampLevelGaps { get; private set; } = null!;
    public IReadOnlyList<SetStampFixedBasicStatDto> SetStampFixedBasicStats { get; private set; } = null!;
    public IReadOnlyList<SetStampPoolBasicStatDto> SetStampPoolBasicStats { get; private set; } = null!;
    public IReadOnlyList<SetStampFixedBasicStatGrowthDto> SetStampFixedBasicStatGrowths { get; private set; } = null!;
    public IReadOnlyList<SetStampPoolBasicStatGrowthDto> SetStampPoolBasicStatGrowths { get; private set; } = null!;
    public IReadOnlyList<SetStampPoolAdvancedStatGrowthDto> SetStampPoolAdvancedStatGrowths { get; private set; } = null!;

    public async Task LoadCacheAsync()
    {
        SetStampNames = (await lookup.GetIdAndText<ushort>(tableName:"set_stamp_names")).ToList();
        SetStamps = (await repo.GetSetStamps()).ToList();
        SetStampTemplates = (await lookup.GetIdAndText<ushort>(tableName:"set_stamp_templates", idColumn:"set_stamp_id", textColumn:"template")).ToList();
        SetStampPassiveNames = (await lookup.GetIdAndText<byte>(tableName:"set_stamp_passive_names")).ToList();
        SetStampPassives = (await repo.GetSetStampPassives()).ToList();
        SetStampPassiveTemplates = (await lookup.GetIdAndText<byte>(tableName:"set_stamp_passive_templates", idColumn:"set_stamp_passive_id", textColumn:"template")).ToList();
        SetStampLevelGaps = (await repo.GetSetStampLevelGaps()).ToList();
        SetStampFixedBasicStats = (await repo.GetSetStampFixedBasicStats()).ToList();
        SetStampPoolBasicStats = (await repo.GetSetStampPoolBasicStats()).ToList();
        SetStampFixedBasicStatGrowths = (await repo.GetSetStampFixedBasicStatGrowths()).ToList();
        SetStampPoolBasicStatGrowths = (await repo.GetSetStampPoolBasicStatGrowths()).ToList();
        SetStampPoolAdvancedStatGrowths = (await repo.GetSetStampPoolAdvancedStatGrowths()).ToList();
    }
}

