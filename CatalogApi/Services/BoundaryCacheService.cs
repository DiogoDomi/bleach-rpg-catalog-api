using CatalogApi.Data.Repositories;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Services;

public class BoundaryCacheService(BoundaryRepository repo, LookupRepository lookup)
{
    public IReadOnlyList<IdTextDto<byte>> BoundaryAscensions { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> BoundaryTypes { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<ushort>> BoundarySkillNames { get; private set; } = null!;
    public IReadOnlyList<BoundaryDto> Boundaries { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<ushort>> BoundaryTemplates { get; private set; } = null!;

    public async Task LoadCacheAsync()
    {
        BoundaryAscensions = (await lookup.GetIdAndText<byte>(tableName:"boundary_ascensions")).ToList();
        BoundaryTypes = (await lookup.GetIdAndText<byte>(tableName:"boundary_types")).ToList();
        BoundarySkillNames = (await lookup.GetIdAndText<ushort>(tableName:"boundary_skill_names")).ToList();
        Boundaries = (await repo.GetBoundaries()).ToList();
        BoundaryTemplates = (await lookup.GetIdAndText<ushort>(tableName:"boundary_templates", idColumn:"boundary_id", textColumn:"template")).ToList();
    }
}

