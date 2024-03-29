﻿namespace ProductsApi.Contracts.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageLink { get; set; }
    public virtual ICollection<Catalog> Catalogs { get; set; } = new List<Catalog>();
}
