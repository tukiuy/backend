using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Compras.Dtos
{
    public class ArticuloRetiros
    {
        public string? NombreArticulo { get; set; }
        public string? ImgArticulo { get; set; }
        public int CantidadRetirados { get; set; }
        public DateTime HoraRetiro { get; set; }
    }
}
