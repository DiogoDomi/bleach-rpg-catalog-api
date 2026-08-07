namespace CatalogApi.Data.Dtos;

public readonly record struct SetStampLevelGapDto(
    byte StarRatingId,
    byte AscensionLevel,
    byte MaxEnhanceLevel
);

