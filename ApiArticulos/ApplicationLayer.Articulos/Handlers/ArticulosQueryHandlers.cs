using DomainLayer.Dtos;
using DomainLayer.Querys;
using InfrastuctureLayer.Articulos.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Articulos.Handlers
{
    public class ArticulosQueryHandlers : IRequestHandler<ObtenerCatalogoPorIdEventoQuery, IEnumerable<ArticuloDto>>
    {
        private readonly TukiPrimaryDatabaseContext _context;

        public ArticulosQueryHandlers(TukiPrimaryDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ArticuloDto>> Handle(ObtenerCatalogoPorIdEventoQuery request, CancellationToken cancellationToken)
        {
            var catalogo = await (from articulos in _context.Articulos
                                  join catalogos in _context.Catalogos on articulos.IdArticulo equals catalogos.IdArticulo
                                  where catalogos.IdEvento == request.Id
                                  && catalogos.Stock == true
                                  select new ArticuloDto
                                  {
                                      Descripcion = articulos.Descripcion,
                                      IdArticulo = articulos.IdArticulo,
                                      ImgPath = articulos.ImgPath,
                                      Nombre = articulos.Nombre,
                                      IdTipoMoneda = catalogos.IdTipoMoneda,
                                      Precio = catalogos.Precio,
                                      Stock = catalogos.Stock
                                  }).ToListAsync();

            return catalogo;
        }

    }
}
