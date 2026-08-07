using CatalogApi.Data.Repositories;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Services;

public class WeaponStampCacheService(WeaponStampRepository repo, LookupRepository lookup)
{
    public IReadOnlyList<IdTextDto<ushort>> WeaponStampNames { get; private set; } = null!;
    public IReadOnlyList<WeaponStampDto> WeaponStamps { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<ushort>> WeaponStampTemplates { get; private set; } = null!;

    public async Task LoadCacheAsync()
    {
        WeaponStampNames = (await lookup.GetIdAndText<ushort>(tableName:"weapon_stamp_names")).ToList();
        WeaponStamps = (await repo.GetWeaponStamps()).ToList();
        WeaponStampTemplates = (await lookup.GetIdAndText<ushort>(tableName:"weapon_stamp_templates", idColumn:"weapon_stamp_id", textColumn:"template")).ToList();
    }
}

