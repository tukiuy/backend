namespace Tuki.Transactions.Api.Contracts.Models;

public  class Transaction
{
    public Guid TransactionId { get; set; }
    public string Trace { get; set; }
    public DateTime Created { get; set; }
    public string Detail { get; set; }
    public string Type { get; set; }
}
