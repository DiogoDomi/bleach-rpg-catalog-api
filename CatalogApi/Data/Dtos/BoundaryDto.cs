namespace CatalogApi.Data.Dtos;

public readonly record struct BoundaryDto(
    ushort? SkillNameId,
    ushort CharacterId,
    byte? ImprovementValue,
    byte AscensionId,
    byte TypeId
);

