using System;
using System.Collections.Generic;

namespace InfrastuctureLayer.Articulos.Context;

public partial class Catalogo
{
    public int IdCatalogo { get; set; }

    public int IdEvento { get; set; }

    public int IdArticulo { get; set; }

    public double Precio { get; set; }

    public int IdTipoMoneda { get; set; }

    public bool Stock { get; set; }

    public int IdComercio { get; set; }

    public virtual Articulo IdArticuloNavigation { get; set; } = null!;
}
