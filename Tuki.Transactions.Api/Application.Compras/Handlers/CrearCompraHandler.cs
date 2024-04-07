using Domain.Compras.Commands;
using Domain.Compras.Dtos;
using InfrastructureLayer.Compras.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;

namespace Application.Compras.Handlers
{
    public class CrearCompraHandler : IRequestHandler<CrearCompraCommand, int>
    {

        private readonly TukiPrimaryDatabaseContext _context;

        public CrearCompraHandler(TukiPrimaryDatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CrearCompraCommand request, CancellationToken cancellationToken)
        {

            //agregar al guardado del comercio
            Compra compra = new Compra()
            {
                EstadoPago = request.EstadoPago,
                FechaCompra = DateTime.Now,
                IdDispositivo = request.IdDispositivo,
                IdEvento = request.IdEvento,
                IdTransaccionMercadoPago = request.IdTransaccionMercadoPago,
                Sub = request.Sub,
                IdComercio = request.IdComercio,
            };
            await _context.Compras.AddAsync(compra);
            await _context.SaveChangesAsync();
            if (compra.IdCompra == 0) return 0;
            var articulos = new List<ArticulosComprado>();
            foreach (ArticuloComprado articulo in request.ArticulosComprados)
            {
                var nuevoarticulo = new ArticulosComprado()
                {
                    IdCompra = compra.IdCompra,
                    IdArticulo = articulo.IdArticulo,
                    CantidadTotal = articulo.Cantidad,
                    CantidadRetirados = 0,
                };
                articulos.Add(nuevoarticulo);
            }

             await _context.BulkInsertAsync(articulos);
            return compra.IdCompra;
        }

    }
}
