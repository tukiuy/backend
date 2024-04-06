using ProductsApi.Contracts.Dtos;
using ProductsApi.Contracts.Querys;
using ProductsApi.Infrastructure.Context;
using MediatR;

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
        var catalogs = _context.Catalogs.Where(x => x.EventId == request.EventId);
        if (catalogs is null)
        {
            throw new Exception();
        }
        throw new NotImplementedException();
    }
}
