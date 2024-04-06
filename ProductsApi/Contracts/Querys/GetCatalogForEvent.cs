using ProductsApi.Contracts.Dtos;
using MediatR;

namespace ProductsApi.Contracts.Querys
{
    public class GetCatalogueForEventQuery : IRequest<IEnumerable<ProductDto>>
    {
        public Guid Id { get; set; }
    }
}
