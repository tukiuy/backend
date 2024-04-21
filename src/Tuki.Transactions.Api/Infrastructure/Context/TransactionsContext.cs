using Microsoft.EntityFrameworkCore;
using Tuki.Transactions.Api.Models;

namespace Tuki.Transactions.Api.Infrastructure.Context;

public partial class TransactionsContext : DbContext
{
    public TransactionsContext() { }
    public TransactionsContext(DbContextOptions<TransactionsContext> opt) : base(opt) { }

    public virtual DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(nameof(Transaction));

        builder.Entity<Transaction>().UseTpcMappingStrategy();

        builder.Entity<Transaction>(e =>
        {
            e.HasKey(x => x.TransactionId);
            e.HasIndex(x => x.Trace);
            e.HasIndex(x => new { x.Type, x.Trace });
        });
            
        builder.Entity<Payment>(e =>
        {
            e.ToTable(nameof(Payment));
            e.HasBaseType(typeof(Transaction));
        });

        OnModelCreatingPartial(builder);
    }

    partial void OnModelCreatingPartial(ModelBuilder builder);
}
