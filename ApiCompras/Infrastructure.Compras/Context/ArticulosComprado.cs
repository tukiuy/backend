using System;
using System.Collections.Generic;

namespace InfrastructureLayer.Compras.Context;

public partial class ArticulosComprado
{
    public int IdArticuloComprado { get; set; }

    public int IdCompra { get; set; }

    public int IdArticulo { get; set; }

    public int CantidadTotal { get; set; }

    public int CantidadRetirados { get; set; }

    public virtual ICollection<ArticulosRetirado> ArticulosRetirados { get; set; } = new List<ArticulosRetirado>();

    public virtual Articulo IdArticuloNavigation { get; set; } = null!;

    public virtual Compra IdCompraNavigation { get; set; } = null!;
}
