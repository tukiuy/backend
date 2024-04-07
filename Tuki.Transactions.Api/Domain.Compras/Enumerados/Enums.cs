using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Compras.Enumerados
{
    public static class Enums
    {
        public enum CodigoRespuesta
        {
            Error = 0,
            Exito = 1,
            IdCompraNoExiste = 2,
            ArticuloCompradoNoEncontrado = 3,
            SuperaLimiteDeRetiros = 4
        }
    }
}
