using ProductsApi.Contracts.Dtos;
using MediatR;

namespace ProductsApi.Contracts.Querys
{
    public class GetEventCatalogQuery : IRequest<IEnumerable<CatalogDto>>
    {
        public Guid EventId { get; set; }
    }
}
