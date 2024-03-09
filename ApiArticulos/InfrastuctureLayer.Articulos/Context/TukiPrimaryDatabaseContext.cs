using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InfrastuctureLayer.Articulos.Context;

public partial class TukiPrimaryDatabaseContext : DbContext
{
    public TukiPrimaryDatabaseContext()
    {
    }

    public TukiPrimaryDatabaseContext(DbContextOptions<TukiPrimaryDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Catalogo> Catalogos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:tuki-prod-server.database.windows.net,1433;Initial Catalog=TukiPrimaryDatabase;Persist Security Info=False;User ID=tuki-prod-login;Password=IvoNacho!2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.IdArticulo);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.ImgPath)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Catalogo>(entity =>
        {
            entity.HasKey(e => e.IdCatalogo).HasName("PK_Catalogo");

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.Catalogos)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Catalogos_Articulos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
