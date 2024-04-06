using ProductsApi.Contracts.Dtos;
using ProductsApi.Contracts.Querys;
using ProductsApi.Infrastructure.Context;
using MediatR;
using ProductsApi.Exceptions;
using ProductsApi.Contracts.Dtos.Extensions;

namespace ProductsApi.Application.Handlers;

public class ArticulosQueryHandlers : IRequestHandler<GetCatalogQuery, IEnumerable<ProductDto>>
{
    private readonly ProductsContext _context;

    public ArticulosQueryHandlers(ProductsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
    {
        var catalogs = _context.Catalogs.Where(x => x.EventId == request.EventId) 
            ?? throw new DomainException($"No catalogs found for event: ${request.EventId}");
        var products = catalogs.Select(x => x.Product.ToDto(x));
        return products;
    }
}
