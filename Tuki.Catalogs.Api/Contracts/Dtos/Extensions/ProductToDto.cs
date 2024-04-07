using Tuki.Catalogs.Api.Contracts.Dtos;
using Tuki.Catalogs.Api.Contracts.Models;

namespace Tuki.Catalogs.Api.Contracts.Dtos.Extensions;

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