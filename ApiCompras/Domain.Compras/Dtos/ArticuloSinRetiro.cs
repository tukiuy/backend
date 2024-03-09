using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Compras.Dtos
{
    public class ArticuloSinRetirar
    {
        public string? NombreArticulo { get; set; }
        public string? ImgArticulo { get; set; }
        public int CantidadSinRetirar { get; set; }
        public int Id { get; set; }
    }
}
