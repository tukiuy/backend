using ProductsApi.Contracts.Dtos;
using ProductsApi.Contracts.Querys;
using ProductsApi.Infrastructure.Context;
using MediatR;
using ProductsApi.Contracts.Dtos.Extensions;

namespace ProductsApi.Application.Handlers;

public class ArticulosQueryHandlers : IRequestHandler<GetCatalogQuery, IEnumerable<CatalogDto>>
{
    private readonly ProductsContext _context;

    public ArticulosQueryHandlers(ProductsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CatalogDto>> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
    {
        var catalogs = from catalog in _context.Catalogs
                       where catalog.EventId == request.EventId
                       group catalog by catalog.StandId into groupedCatalog
                       select new CatalogDto 
                       {
                            Id = groupedCatalog.Key,
                            Stand = groupedCatalog.First().Stand.Name,
                            Products = groupedCatalog.Select(x => x.Product.ToDto(x.Price))
                       };
                       
        return catalogs.AsEnumerable();
    }
}
