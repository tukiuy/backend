using Microsoft.EntityFrameworkCore;
using Tuki.Transactions.Api.Contracts.Models;

namespace Tuki.Transactions.Api.Infrastructure.Context;

public partial class TransactionsContext : DbContext
{
    public TransactionsContext() { }
    public TransactionsContext(DbContextOptions<TransactionsContext> opt) : base(opt) { }

    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<Payment> Payment { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(nameof(Transaction));

        builder.Entity<Transaction>(e =>
        {
            e.ToTable("transactions");
            e.HasKey(x => x.TransactionId);
            e.HasDiscriminator(x => x.Type);
            e.HasIndex(x => new { x.Type, x.Trace });
            e.HasIndex(x => x.Trace);
        });        

        builder.Entity<Payment>(e =>
        {
            e.HasBaseType(typeof(Transaction));
        });

        OnModelCreatingPartial(builder);
    }

    partial void OnModelCreatingPartial(ModelBuilder builder);
}
