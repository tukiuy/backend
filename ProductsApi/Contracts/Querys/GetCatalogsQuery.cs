using ProductsApi.Contracts.Dtos;
using MediatR;

namespace ProductsApi.Contracts.Querys
{
    public class GetCatalogQuery : IRequest<IEnumerable<ProductDto>>
    {
        public Guid EventId { get; set; }
    }
}
