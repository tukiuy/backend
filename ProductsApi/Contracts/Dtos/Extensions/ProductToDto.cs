using ProductsApi.Contracts.Models;

namespace ProductsApi.Contracts.Dtos.Extensions;

public static class ProductToDto
{
    public static ProductDto ToDto(this Product model, double price) => new()
    {
        Id = model.Id,
        Name = model.Name,    
        Description = model.Description,
        ImageLink = model.ImageLink,
        Price = price
    };
}