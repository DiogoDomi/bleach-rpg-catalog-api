using CatalogApi.Data.Repositories;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Services;

public class CharacterCacheService(CharacterRepository repo, LookupRepository lookup)
{
    public IReadOnlyList<IdTextDto<ushort>> CharacterNames { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> CharacterAffinities { get; private set; } = null!;
    public IReadOnlyList<CharacterRoleDto> CharacterRoles { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> CharacterFactions { get; private set; } = null!;
    public IReadOnlyList<CharacterDto> Characters { get; private set; } = null!;
    public IReadOnlyList<CharacterBaseStatDto> CharacterBaseStats { get; private set; } = null!;

    public async Task LoadCacheAsync()
    {
        CharacterNames = (await lookup.GetIdAndText<ushort>(tableName:"character_names")).ToList();
        CharacterAffinities = (await lookup.GetIdAndText<byte>(tableName:"character_affinities")).ToList();
        CharacterRoles = (await repo.GetCharacterRoles()).ToList();
        CharacterFactions = (await lookup.GetIdAndText<byte>(tableName:"character_factions")).ToList();
        Characters = (await repo.GetCharacters()).ToList();
        CharacterBaseStats = (await repo.GetCharacterBaseStats()).ToList();
    }
}

