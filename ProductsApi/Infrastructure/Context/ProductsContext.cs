using ProductsApi.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Infrastructure.Context;

public partial class ProductsContext : DbContext
{
    public ProductsContext()
    {
    }

    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Articulos { get; set; }

    public virtual DbSet<Catalog> Catalogos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Description)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.ImageLink)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Catalog>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.Catalogs)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Catalogue_Products");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
