using System;
using System.Collections.Generic;

namespace InfrastuctureLayer.Articulos.Context;

public partial class Articulo
{
    public int IdArticulo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? ImgPath { get; set; }

    public virtual ICollection<Catalogo> Catalogos { get; set; } = new List<Catalogo>();
}
