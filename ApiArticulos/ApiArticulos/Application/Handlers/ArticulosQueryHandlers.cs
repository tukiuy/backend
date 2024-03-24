using ProductsApi.Contracts.Dtos;
using ProductsApi.Contracts.Querys;
using ProductsApi.Infrastructure.Context;
using MediatR;

namespace ProductsApi.Application.Handlers;

public class ArticulosQueryHandlers : IRequestHandler<GetCatalogueForEventQuery, IEnumerable<ProductDto>>
{
    private readonly ProductsContext _context;

    public ArticulosQueryHandlers(ProductsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetCatalogueForEventQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
