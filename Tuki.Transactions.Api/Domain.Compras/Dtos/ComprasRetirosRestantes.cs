using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Compras.Dtos
{
    public class ComprasRetirosRestantes
    {
        public List<CompraRetirosRestantes> Compras { get; set; } = new List<CompraRetirosRestantes>();
    }
}
