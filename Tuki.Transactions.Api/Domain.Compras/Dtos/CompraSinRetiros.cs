using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Compras.Dtos
{
    public class CompraRetirosRestantes
    {
        public CompraDto Compra { get; set; } = new CompraDto();
        public List<ArticuloSinRetirar> Articulos { get; set; } = new List<ArticuloSinRetirar>();
    }
}
