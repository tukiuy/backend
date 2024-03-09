using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainLayer.Compras.Enumerados.Enums;

namespace DomainLayer.Compras.Dtos.Respuestas
{
    public class CrearEntregaRespuesta
    {
        public CodigoRespuesta codigoRespuesta { get; set; } = CodigoRespuesta.Error;
       
    }
}
