namespace CatalogApi.Services;

public class CatalogCacheService(
    LookupCacheService lookupService,
    CharacterCacheService characterService,
    WeaponCacheService weaponService,
    SkillCacheService skillService,
    BoundaryCacheService boundaryService,
    WeaponStampCacheService weaponStampService,
    CoreStampCacheService coreStampService,
    SetStampCacheService setStampService,
    ItemCacheService itemService,
    GameConfigCacheService gameConfigService
)
{
    public async Task LoadAllCacheAsync()
    {
        await lookupService.LoadCacheAsync();
        await characterService.LoadCacheAsync();
        await weaponService.LoadCacheAsync();
        await skillService.LoadCacheAsync();
        await boundaryService.LoadCacheAsync();
        await weaponStampService.LoadCacheAsync();
        await coreStampService.LoadCacheAsync();
        await setStampService.LoadCacheAsync();
        await itemService.LoadCacheAsync();
        await gameConfigService.LoadCacheAsync();
    }
}

