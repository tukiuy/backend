namespace InfrastructureLayer.Compras.Context;

public partial class Compra
{
    public int IdCompra { get; set; }

    public string IdDispositivo { get; set; } = null!;

    public DateTime FechaCompra { get; set; }

    public int IdTransaccionMercadoPago { get; set; }

    public int IdEvento { get; set; }

    public string EstadoPago { get; set; } = null!;

    public string Sub { get; set; } = null!;

    public int IdComercio { get; set; }

    public virtual ICollection<ArticulosComprado> ArticulosComprados { get; set; } = new List<ArticulosComprado>();
}
