namespace Tuki.Transactions.Api.Models;

public abstract class Transaction
{
    public Guid TransactionId { get; set; }
    public string Trace { get; set; }
    public DateTime Created { get; set; }
    public string Detail { get; set; }
    public string Type { get; set; }
}
