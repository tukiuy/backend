using ProductsApi.Contracts.Dtos;

namespace ProductsApi.Contracts.Querys;

public record GetCatalogsForEventResponse
{
    public IList<CatalogDto> Catalogs { get; set; }
}
