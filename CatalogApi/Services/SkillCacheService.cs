using CatalogApi.Data.Repositories;
using CatalogApi.Data.Dtos;

namespace CatalogApi.Services;

public class SkillCacheService(SkillRepository repo, LookupRepository lookup)
{
    public IReadOnlyList<IdTextDto<ushort>> SkillNames { get; private set; } = null!;
    public IReadOnlyList<SkillCategoryDto> SkillCategories { get; private set; } = null!;
    public IReadOnlyList<SkillSubCategoryDto> SkillSubCategories { get; private set; } = null!;
    public IReadOnlyList<SkillDto> Skills { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<ushort>> SkillUseStates { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<ushort>> SkillTemplates { get; private set; } = null!;
    public IReadOnlyList<IdTextDto<byte>> SkillTags { get; private set; } = null!;
    public IReadOnlyList<SkillTagMappingDto> SkillTagMapping { get; private set; } = null!;

    public async Task LoadCacheAsync()
    {
        SkillNames = (await lookup.GetIdAndText<ushort>(tableName:"skill_names")).ToList();
        SkillCategories = (await repo.GetSkillCategories()).ToList();
        SkillSubCategories = (await repo.GetSkillSubCategories()).ToList();
        Skills = (await repo.GetSkills()).ToList();
        SkillUseStates = (await lookup.GetIdAndText<ushort>(tableName:"skill_use_states", idColumn:"skill_id", textColumn:"template")).ToList();
        SkillTemplates = (await lookup.GetIdAndText<ushort>(tableName:"skill_templates", idColumn:"skill_id", textColumn:"template")).ToList();
        SkillTags = (await lookup.GetIdAndText<byte>(tableName:"skill_tags")).ToList();
        SkillTagMapping = (await repo.GetSkillTagMapping()).ToList();
    }
}

