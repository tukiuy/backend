﻿namespace Tuki.Catalogs.Api.Contracts.Models;

public class Stand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Catalog Catalog { get; set; }
}
