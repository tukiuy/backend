using Domain.Compras.Dtos;
using DomainLayer.Compras.Dtos;
using DomainLayer.Compras.Dtos.Respuestas;
using MediatR;

namespace Domain.Compras.Commands
{
    public class CrearEntregaCommand : IRequest<CrearEntregaRespuesta>
    {
        public int IdCompra { get; set; }
        public int IdPuntoDeEntrega { get; set; }
        public List<Articulo> Articulos{ get; set; } = new List<Articulo>();
    }
}