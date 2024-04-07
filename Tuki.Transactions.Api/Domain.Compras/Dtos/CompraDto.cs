using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Compras.Dtos
{
    public class CompraDto
    {
        public int IdCompra { get; set; }

        public DateTime FechaCompra { get; set; }

        public long? IdTransaccion { get; set;}
    }
}
