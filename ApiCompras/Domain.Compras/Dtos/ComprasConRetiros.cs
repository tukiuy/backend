using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Compras.Dtos
{
    public class ComprasConRetiros
    {
        public List<CompraConRetiros> Compras { get; set; } = new List<CompraConRetiros>();
    }
}
