using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Compras.Context;

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

    public virtual DbSet<ArticulosComprado> ArticulosComprados { get; set; }

    public virtual DbSet<ArticulosRetirado> ArticulosRetirados { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Retiro> Retiros { get; set; }

    public virtual DbSet<TransaccionesMercadoPago> TransaccionesMercadoPagos { get; set; }

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

        modelBuilder.Entity<ArticulosComprado>(entity =>
        {
            entity.HasKey(e => e.IdArticuloComprado);

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.ArticulosComprados)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArticulosComprados_Articulos");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.ArticulosComprados)
                .HasForeignKey(d => d.IdCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArticulosComprados_Compras");
        });

        modelBuilder.Entity<ArticulosRetirado>(entity =>
        {
            entity.HasKey(e => e.IdArticulosRetirados);

            entity.HasOne(d => d.IdArticuloCompradoNavigation).WithMany(p => p.ArticulosRetirados)
                .HasForeignKey(d => d.IdArticuloComprado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArticulosRetirados_ArticulosComprados");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra);

            entity.Property(e => e.EstadoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaCompra).HasColumnType("datetime");
            entity.Property(e => e.IdComercio).HasColumnName("idComercio");
            entity.Property(e => e.IdDispositivo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Sub)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Retiro>(entity =>
        {
            entity.HasKey(e => e.IdRetiro);

            entity.Property(e => e.Hora).HasColumnType("datetime");
        });

        modelBuilder.Entity<TransaccionesMercadoPago>(entity =>
        {
            entity.HasKey(e => e.IdTransaccionMercadoPago).HasName("PK_Pagos");

            entity.ToTable("TransaccionesMercadoPagos", "Transacciones");

            entity.Property(e => e.AuthorizationCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DateApproved).HasColumnType("datetime");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateLastUpdated).HasColumnType("datetime");
            entity.Property(e => e.DateOfExpiration).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Installments).HasColumnName("installments");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IssuerId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MoneyReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.OperationType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Payer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentMethodId)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PaymentTypeId)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Shipments)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.StatusDetail)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.TransactionAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("transactionAmount");
            entity.Property(e => e.TransactionAmountRefunded)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("transactionAmountRefunded");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
