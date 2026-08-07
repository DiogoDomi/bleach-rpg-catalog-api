namespace CatalogApi.Data.Dtos;

public readonly record struct IdTextDto<T>(string Text, T Id);

