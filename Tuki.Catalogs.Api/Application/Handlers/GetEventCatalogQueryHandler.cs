using MediatR;
using Tuki.Catalogs.Api.Contracts.Querys;
using Tuki.Catalogs.Api.Contracts.Dtos.Extensions;
using Tuki.Catalogs.Api.Infrastructure.Context;
using Tuki.Catalogs.Api.Contracts.Dtos;

namespace Tuki.Catalogs.Api.Application.Handlers;

public class GetEventCatalogQueryHandler(ProductsContext context)
    : IRequestHandler<GetEventCatalogQuery, IEnumerable<CatalogDto>>
{
    private readonly ProductsContext _context = context;

    public async Task<IEnumerable<CatalogDto>> Handle(GetEventCatalogQuery request, CancellationToken cancellationToken)
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
