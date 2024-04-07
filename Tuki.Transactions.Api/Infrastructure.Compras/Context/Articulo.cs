using System;
using System.Collections.Generic;

namespace InfrastructureLayer.Compras.Context;

public partial class Articulo
{
    public int IdArticulo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? ImgPath { get; set; }

    public virtual ICollection<ArticulosComprado> ArticulosComprados { get; set; } = new List<ArticulosComprado>();
}
