using System;
using System.Collections.Generic;

namespace InfrastructureLayer.Compras.Context;

public partial class Retiro
{
    public int IdRetiro { get; set; }

    public DateTime Hora { get; set; }

    public int IdPuntoDeEntrega { get; set; }
}
