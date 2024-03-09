using DomainLayer.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Querys
{
    public class ObtenerCatalogoPorIdEventoQuery : IRequest<IEnumerable<ArticuloDto>>
    {
        public int Id { get; set; }
    }
}
