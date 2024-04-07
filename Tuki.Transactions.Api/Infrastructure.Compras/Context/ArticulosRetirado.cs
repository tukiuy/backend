using System;
using System.Collections.Generic;

namespace InfrastructureLayer.Compras.Context;

public partial class ArticulosRetirado
{
    public int IdArticulosRetirados { get; set; }

    public int IdRetiro { get; set; }

    public int IdArticuloComprado { get; set; }

    public int CantidadArticulosRetirados { get; set; }

    public virtual ArticulosComprado IdArticuloCompradoNavigation { get; set; } = null!;
}
