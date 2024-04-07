using DomainLayer.Compras.Dtos;
using DomainLayer.Compras.Querys;
using InfrastructureLayer.Compras.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Compras.Handlers
{
    public class ObtenerComprasConRetirosRestantesHandler : IRequestHandler<ObtenerComprasConRetirosRestantesQuery, ComprasRetirosRestantes>
    {
        private readonly TukiPrimaryDatabaseContext _context;

        public ObtenerComprasConRetirosRestantesHandler(TukiPrimaryDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ComprasRetirosRestantes> Handle(ObtenerComprasConRetirosRestantesQuery request, CancellationToken cancellationToken)
        {
            ComprasRetirosRestantes comprasSinRetiros = new ComprasRetirosRestantes();
            var _compras = await (from compra in _context.Compras
                                  where compra.IdDispositivo == request.IdDispositivo && compra.IdEvento == request.idEvento
                                  select new CompraDto
                                  {
                                      IdCompra = compra.IdCompra,
                                      FechaCompra = compra.FechaCompra,
                                      IdTransaccion = compra.IdTransaccionMercadoPago,
                                  }).ToListAsync();

            foreach (CompraDto c in _compras)
            {
                var articulosResult = await (from articuloComprado in _context.ArticulosComprados
                                                      join articulo in _context.Articulos
                                                      on articuloComprado.IdArticulo equals articulo.IdArticulo
                                                      where articuloComprado.IdCompra == c.IdCompra
                                                      select new DomainLayer.Compras.Dtos.ArticuloSinRetirar
                                                      {
                                                          CantidadSinRetirar = (articuloComprado.CantidadTotal - articuloComprado.CantidadRetirados),
                                                          ImgArticulo = articulo.ImgPath,
                                                          NombreArticulo = articulo.Nombre,
                                                          Id = articulo.IdArticulo
                                                      }).ToListAsync();
                DomainLayer.Compras.Dtos.CompraRetirosRestantes compra = new DomainLayer.Compras.Dtos.CompraRetirosRestantes();
                compra.Compra.IdCompra = c.IdCompra;
                compra.Compra.FechaCompra = c.FechaCompra;
                compra.Compra.IdTransaccion = c.IdTransaccion;
                compra.Articulos = articulosResult;
                comprasSinRetiros.Compras.Add(compra);
            }
            return comprasSinRetiros;
        }
    }
}
