using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Dtos
{
    public class ArticuloDto
    {
        public int IdArticulo { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string? ImgPath { get; set; }

        public double Precio { get; set; }

        public int IdTipoMoneda { get; set; }

        public bool Stock { get; set; }

    }
}
