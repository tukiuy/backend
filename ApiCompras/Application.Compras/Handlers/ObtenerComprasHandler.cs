using DomainLayer.Compras.Dtos;
using DomainLayer.Compras.Querys;
using InfrastructureLayer.Compras.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace ApplicationLayer.Compras.Handlers
{
    public class ObtenerComprasHandler : IRequestHandler<ObtenerComprasQuery, List<CompraCompletaDto>>
    {
        private readonly TukiPrimaryDatabaseContext _context;
        public ObtenerComprasHandler(TukiPrimaryDatabaseContext ctx)
        {
           _context = ctx; 
        }
        public async Task<List<CompraCompletaDto>> Handle(ObtenerComprasQuery request, CancellationToken cancellationToken)
        {
            List<CompraCompletaDto> comprasDto = new();
            var compras = await _context.Compras
                .Where(x => x.IdEvento == request.IdEvento && x.IdDispositivo == request.IdDispositivo)
                .Select(x => new CompraCompletaDto 
                {
                    Id = x.IdCompra,
                    PaymentId = x.IdTransaccionMercadoPago,
                    User = x.Sub,
                    Device = x.IdDispositivo,
                    Created = x.FechaCompra
                })
                .ToListAsync(); 
                
            foreach (var compra in compras)
            {
                var articulos = from articuloComprado in _context.ArticulosComprados
                                join articulo in _context.Articulos on articuloComprado.IdArticulo equals articulo.IdArticulo
                                where articuloComprado.IdCompra == compra.Id
                                select new ArticuloDto 
                                {
                                    Id = articuloComprado.IdArticulo,
                                    Name = articulo.Nombre,
                                    Description = articulo.Descripcion,
                                    ImageUrl = articulo.ImgPath,
                                    Quantity = articuloComprado.CantidadTotal
                                };
                comprasDto.Add(new CompraCompletaDto(compra, articulos.ToList()));
            }
            Console.WriteLine($"Compras totales: {comprasDto.Count()}");
            return comprasDto;
        }
    }
}