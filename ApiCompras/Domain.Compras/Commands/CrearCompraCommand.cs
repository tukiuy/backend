using Domain.Compras.Dtos;
using MediatR;

namespace Domain.Compras.Commands
{
    public class CrearCompraCommand : IRequest<int>
    {
        public string? Sub { get; set; }
        public string? IdDispositivo { get; set; }
        public int IdEvento { get; set; }
        public List<ArticuloComprado> ArticulosComprados { get; set; } = new List<ArticuloComprado>();
        public int IdTransaccionMercadoPago { get; set; }
        public string? EstadoPago { get; set; }
        public int IdComercio {  get; set; }
    }
}