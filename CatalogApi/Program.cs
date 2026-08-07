using CatalogApi.Data.Repositories;
using CatalogApi.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<LookupRepository>();
builder.Services.AddSingleton<CharacterRepository>();
builder.Services.AddSingleton<WeaponRepository>();
builder.Services.AddSingleton<SkillRepository>();
builder.Services.AddSingleton<BoundaryRepository>();
builder.Services.AddSingleton<WeaponStampRepository>();
builder.Services.AddSingleton<CoreStampRepository>();
builder.Services.AddSingleton<SetStampRepository>();
builder.Services.AddSingleton<ItemRepository>();
builder.Services.AddSingleton<GameConfigRepository>();

builder.Services.AddSingleton<LookupCacheService>();
builder.Services.AddSingleton<CharacterCacheService>();
builder.Services.AddSingleton<WeaponCacheService>();
builder.Services.AddSingleton<SkillCacheService>();
builder.Services.AddSingleton<BoundaryCacheService>();
builder.Services.AddSingleton<WeaponStampCacheService>();
builder.Services.AddSingleton<CoreStampCacheService>();
builder.Services.AddSingleton<SetStampCacheService>();
builder.Services.AddSingleton<ItemCacheService>();
builder.Services.AddSingleton<GameConfigCacheService>();

builder.Services.AddSingleton<CatalogCacheService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API v1");
        options.RoutePrefix = string.Empty;
    });
}

await app.Services.GetRequiredService<CatalogCacheService>().LoadAllCacheAsync();

app.MapGet("/rarities", (LookupCacheService cache) => cache.Rarities);
app.MapGet("/stat_types", (LookupCacheService cache) => cache.StatTypes);
app.MapGet("/star_ratings", (LookupCacheService cache) => cache.StarRatings);

app.MapGet("/character_names", (CharacterCacheService cache) => cache.CharacterNames);
app.MapGet("/character_affinities", (CharacterCacheService cache) => cache.CharacterAffinities);
app.MapGet("/character_roles", (CharacterCacheService cache) => cache.CharacterRoles);
app.MapGet("/character_factions", (CharacterCacheService cache) => cache.CharacterFactions);
app.MapGet("/characters", (CharacterCacheService cache) => cache.Characters);
app.MapGet("/character_base_stats", (CharacterCacheService cache) => cache.CharacterBaseStats);

app.MapGet("/weapon_names", (WeaponCacheService cache) => cache.WeaponNames);
app.MapGet("/weapon_types", (WeaponCacheService cache) => cache.WeaponTypes);
app.MapGet("/weapons", (WeaponCacheService cache) => cache.Weapons);
app.MapGet("/weapon_base_stats", (WeaponCacheService cache) => cache.WeaponBaseStats);

app.MapGet("/skill_names", (SkillCacheService cache) => cache.SkillNames);
app.MapGet("/skill_categories", (SkillCacheService cache) => cache.SkillCategories);
app.MapGet("/skill_subcategories", (SkillCacheService cache) => cache.SkillSubCategories);
app.MapGet("/skills", (SkillCacheService cache) => cache.Skills);
app.MapGet("/skill_use_states", (SkillCacheService cache) => cache.SkillUseStates);
app.MapGet("/skill_templates", (SkillCacheService cache) => cache.SkillTemplates);
app.MapGet("/skill_tags", (SkillCacheService cache) => cache.SkillTags);
app.MapGet("/skill_tag_mapping", (SkillCacheService cache) => cache.SkillTagMapping);

app.MapGet("/boundary_ascensions", (BoundaryCacheService cache) => cache.BoundaryAscensions);
app.MapGet("/boundary_types", (BoundaryCacheService cache) => cache.BoundaryTypes);
app.MapGet("/boundary_skill_names", (BoundaryCacheService cache) => cache.BoundarySkillNames);
app.MapGet("/boundaries", (BoundaryCacheService cache) => cache.Boundaries);
app.MapGet("/boundary_templates", (BoundaryCacheService cache) => cache.BoundaryTemplates);

app.MapGet("/weapon_stamp_names", (WeaponStampCacheService cache) => cache.WeaponStampNames);
app.MapGet("/weapon_stamps", (WeaponStampCacheService cache) => cache.WeaponStamps);
app.MapGet("/weapon_stamp_templates", (WeaponStampCacheService cache) => cache.WeaponStampTemplates);

app.MapGet("/core_stamp_names", (CoreStampCacheService cache) => cache.CoreStampNames);
app.MapGet("/core_stamps", (CoreStampCacheService cache) => cache.CoreStamps);
app.MapGet("/core_stamp_templates", (CoreStampCacheService cache) => cache.CoreStampTemplates);
app.MapGet("/core_stamp_base_stats", (CoreStampCacheService cache) => cache.CoreStampBaseStats);

app.MapGet("/set_stamp_names", (SetStampCacheService cache) => cache.SetStampNames);
app.MapGet("/set_stamps", (SetStampCacheService cache) => cache.SetStamps);
app.MapGet("/set_stamp_templates", (SetStampCacheService cache) => cache.SetStampTemplates);
app.MapGet("/set_stamp_passive_names", (SetStampCacheService cache) => cache.SetStampPassiveNames);
app.MapGet("/set_stamp_passives", (SetStampCacheService cache) => cache.SetStampPassives);
app.MapGet("/set_stamp_passive_templates", (SetStampCacheService cache) => cache.SetStampPassiveTemplates);
app.MapGet("/set_stamp_level_gaps", (SetStampCacheService cache) => cache.SetStampLevelGaps);
app.MapGet("/set_stamp_fixed_basic_stats", (SetStampCacheService cache) => cache.SetStampFixedBasicStats);
app.MapGet("/set_stamp_pool_basic_stats", (SetStampCacheService cache) => cache.SetStampPoolBasicStats);
app.MapGet("/set_stamp_fixed_basic_stat_growths", (SetStampCacheService cache) => cache.SetStampFixedBasicStatGrowths);
app.MapGet("/set_stamp_pool_basic_stat_growths", (SetStampCacheService cache) => cache.SetStampPoolBasicStatGrowths);
app.MapGet("/set_stamp_pool_advanced_stat_growths", (SetStampCacheService cache) => cache.SetStampPoolAdvancedStatGrowths);

app.MapGet("/item_names", (ItemCacheService cache) => cache.ItemNames);
app.MapGet("/item_categories", (ItemCacheService cache) => cache.ItemCategories);
app.MapGet("/item_types", (ItemCacheService cache) => cache.ItemTypes);
app.MapGet("/items", (ItemCacheService cache) => cache.Items);
app.MapGet("/item_descriptions", (ItemCacheService cache) => cache.ItemDescriptions);

app.MapGet("/character_max_upgrade_costs", (GameConfigCacheService cache) => cache.CharacterMaxUpgradeCosts);
app.MapGet("/entity_types", (GameConfigCacheService cache) => cache.EntityTypes);
app.MapGet("/limited_gacha_guaranteed_pull_costs", (GameConfigCacheService cache) => cache.LimitedGachaGuaranteedPullCosts);
app.MapGet("/game_level_configs", (GameConfigCacheService cache) => cache.GameLevelConfigs);

app.Run();

