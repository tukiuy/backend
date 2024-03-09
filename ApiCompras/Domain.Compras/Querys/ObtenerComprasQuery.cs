using DomainLayer.Compras.Dtos;
using MediatR;

namespace DomainLayer.Compras.Querys
{ 
    public class ObtenerComprasQuery : IRequest<List<CompraCompletaDto>> 
    { 
        public int IdEvento { get; set; }
        public string IdDispositivo { get; set; } = string.Empty;
    } 
}