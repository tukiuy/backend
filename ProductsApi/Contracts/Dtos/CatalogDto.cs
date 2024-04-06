namespace ProductsApi.Contracts.Dtos;

public record CatalogDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IList<ProductDto> Products { get; set; }
}
