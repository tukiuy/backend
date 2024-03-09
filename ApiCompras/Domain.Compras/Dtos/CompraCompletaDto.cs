namespace DomainLayer.Compras.Dtos 
{
    public class CompraCompletaDto 
    {
        public CompraCompletaDto(CompraCompletaDto compra, List<ArticuloDto> articulos)
        {
            Id = compra.Id;
            PaymentId = compra.PaymentId;
            User = compra.User;
            Device = compra.Device;
            Items = articulos;
            Created = compra.Created;
        }
        public CompraCompletaDto() { }
        
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public string User { get; set; } = string.Empty;
        public string Device { get; set; } = string.Empty;
        public List<ArticuloDto> Items { get; set; } = new();
        public DateTime Created { get; set; }
        public string Status { get; set; } = "approved";        
 
    }
    public class ArticuloDto 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool InStock { get; } = true;
        public int Price { get; } = 0;
        public int Quantity { get; set; }
    }
}