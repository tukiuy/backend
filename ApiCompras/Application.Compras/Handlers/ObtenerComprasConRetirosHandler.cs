using DomainLayer.Compras.Dtos;
using DomainLayer.Compras.Querys;
using InfrastructureLayer.Compras.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Compras.Handlers
{
    public class ObtenerComprasConRetirosHandler : IRequestHandler<ObtenerComprasConRetirosQuery, ComprasConRetiros>
    {
        private readonly TukiPrimaryDatabaseContext _context;

        public ObtenerComprasConRetirosHandler(TukiPrimaryDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ComprasConRetiros> Handle(ObtenerComprasConRetirosQuery request, CancellationToken cancellationToken)
        {
            ComprasConRetiros comprasConRetiros = new ComprasConRetiros();
            var _compras = await (from compra in _context.Compras
                                  join transaccionesmMercadoPago in _context.TransaccionesMercadoPagos on compra.IdTransaccionMercadoPago equals transaccionesmMercadoPago.IdTransaccionMercadoPago
                                  where compra.IdDispositivo == request.IdDispositivo && compra.IdEvento == request.idEvento
                                  select new CompraDto
                                  {
                                        IdCompra = compra.IdCompra,
                                         FechaCompra = compra.FechaCompra,
                                          IdTransaccion = transaccionesmMercadoPago.Id,
                                  }).ToListAsync();


            foreach (CompraDto c in _compras)
            {
                var articulosResult = await (from articuloComprado in _context.ArticulosComprados
                                         join articulo in _context.Articulos on articuloComprado.IdArticulo equals articulo.IdArticulo
                                         join articuloRetirado in _context.ArticulosRetirados on articuloComprado.IdArticuloComprado equals articuloRetirado.IdArticuloComprado
                                         join retiro in _context.Retiros on articuloRetirado.IdRetiro equals retiro.IdRetiro
                                         where articuloComprado.IdCompra == c.IdCompra
                                         select new DomainLayer.Compras.Dtos.ArticuloRetiros
                                         {
                                             CantidadRetirados = articuloComprado.CantidadRetirados,
                                             ImgArticulo = articulo.ImgPath,
                                             NombreArticulo = articulo.Nombre,   
                                             HoraRetiro = retiro.Hora,
                                         }).ToListAsync();
                DomainLayer.Compras.Dtos.CompraConRetiros compra = new DomainLayer.Compras.Dtos.CompraConRetiros();
                compra.Compra.IdCompra = c.IdCompra;
                compra.Compra.FechaCompra = c.FechaCompra;
                compra.Compra.IdTransaccion = c.IdTransaccion;
                compra.Articulos = articulosResult;
                comprasConRetiros.Compras.Add(compra);
            } 
            return comprasConRetiros;
        }
    }
}
