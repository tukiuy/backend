using Domain.Compras.Commands;
using DomainLayer.Compras.Dtos.Respuestas;
using InfrastructureLayer.Compras.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Compras.Handlers
{
    public class CrearEntregaHandler : IRequestHandler<CrearEntregaCommand, CrearEntregaRespuesta>
    {
        private readonly TukiPrimaryDatabaseContext _context;

        public CrearEntregaHandler(TukiPrimaryDatabaseContext context)
        {
            _context = context;
        }

        public async Task<CrearEntregaRespuesta> Handle(CrearEntregaCommand request, CancellationToken cancellationToken)
        {
            //agregar validacion de si ese es el comercio correcto de entrega

            CrearEntregaRespuesta crearEntregaRespuesta = new CrearEntregaRespuesta();
            bool guardararticulos = true;
            var compra = await _context.Compras.FirstOrDefaultAsync(x => x.IdCompra == request.IdCompra);
            if (compra is null)
            {
                crearEntregaRespuesta = new CrearEntregaRespuesta()
                {
                    codigoRespuesta = DomainLayer.Compras.Enumerados.Enums.CodigoRespuesta.IdCompraNoExiste,
                };
            };

            foreach(DomainLayer.Compras.Dtos.Articulo articulo in request.Articulos)
            {
                var articulosComprado = await _context.ArticulosComprados.FirstOrDefaultAsync(x => x.IdCompra == request.IdCompra && x.IdArticulo == articulo.IdArticulo);
                if (articulosComprado is null)
                {
                    crearEntregaRespuesta.codigoRespuesta = DomainLayer.Compras.Enumerados.Enums.CodigoRespuesta.ArticuloCompradoNoEncontrado;
                    guardararticulos = false;
                    break;
                }

                bool RetirosPermitido = articulosComprado.CantidadRetirados + articulo.Cantidad <= articulosComprado.CantidadTotal ? true : false;

                if (!RetirosPermitido)
                {
                    crearEntregaRespuesta.codigoRespuesta = DomainLayer.Compras.Enumerados.Enums.CodigoRespuesta.SuperaLimiteDeRetiros;
                    guardararticulos = false;
                    break;
                }

                articulosComprado.CantidadRetirados = articulosComprado.CantidadRetirados + articulo.Cantidad;

                _context.Entry(articulosComprado).State = EntityState.Modified;
                
            }

            if (guardararticulos)
            {
                await _context.SaveChangesAsync();
                crearEntregaRespuesta.codigoRespuesta = DomainLayer.Compras.Enumerados.Enums.CodigoRespuesta.Exito;
            }
            
            return crearEntregaRespuesta;
        }
            
    }
 }

