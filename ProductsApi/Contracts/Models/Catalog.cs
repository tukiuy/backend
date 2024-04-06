namespace ProductsApi.Contracts.Models;

public class Catalog
{
    public Guid EventId { get; set; }
    public Guid ProductId { get; set; }
    public Guid StandId { get; set; }
    public double Price { get; set; }
    public bool Stock { get; set; }
    public Product Product { get; set; } = null!;
    public Stand Stand { get; set; } = null!;
}
