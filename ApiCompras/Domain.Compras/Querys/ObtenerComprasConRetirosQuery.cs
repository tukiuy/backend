using DomainLayer.Compras.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Compras.Querys
{
    public class ObtenerComprasConRetirosQuery : IRequest<ComprasConRetiros>
    {
        public string? IdDispositivo { get; set; }
        public int idEvento { get; set; }
    }
}
