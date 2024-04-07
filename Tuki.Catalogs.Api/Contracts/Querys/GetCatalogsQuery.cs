using MediatR;
using Tuki.Catalogs.Api.Contracts.Dtos;

namespace Tuki.Catalogs.Api.Contracts.Querys
{
    public class GetEventCatalogQuery : IRequest<IEnumerable<CatalogDto>>
    {
        public Guid EventId { get; set; }
    }
}
