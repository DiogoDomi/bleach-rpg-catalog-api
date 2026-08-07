using CatalogApi.Data.Repositories;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Services;

public class WeaponCacheService(WeaponRepository repo, LookupRepository lookup)
{
    public IReadOnlyList<IdTextDto<ushort>> WeaponNames { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> WeaponTypes { get; private set; } = null!;
    public IReadOnlyList<WeaponDto> Weapons { get; private set; } = null!;
    public IReadOnlyList<WeaponBaseStatDto> WeaponBaseStats { get; private set; } = null!;

    public async Task LoadCacheAsync()
    {
        WeaponNames = (await lookup.GetIdAndText<ushort>(tableName:"weapon_names")).ToList();
        WeaponTypes = (await lookup.GetIdAndText<byte>(tableName:"weapon_types")).ToList();
        Weapons = (await repo.GetWeapons()).ToList();
        WeaponBaseStats = (await repo.GetWeaponBaseStats()).ToList();
    }
}

