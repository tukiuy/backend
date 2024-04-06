namespace ProductsApi.Contracts.Dtos;

public record CatalogDto
{
    public Guid Id { get; set; }
    public string Stand { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }
}
