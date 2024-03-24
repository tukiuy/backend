namespace ProductsApi.Contracts.Dtos;

public record ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageLink { get; set; }
    public double Price { get; set; }
}
