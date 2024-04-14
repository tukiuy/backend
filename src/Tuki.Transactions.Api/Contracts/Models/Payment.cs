using System.Security.Cryptography;
using System.Text;
using Tuki.Common.Constants;
using Tuki.Common.Utils;

namespace Tuki.Transactions.Api.Contracts.Models;

public class Payment : Transaction
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public Guid UserId { get; set; }
    public Guid EventId { get; set; }

    public Payment(Guid id, string status, Guid userId, Guid eventId)
    {
        var trace = $"{userId}{eventId}";
        Id = id;
        Status = status;
        UserId = userId;
        EventId = eventId;
        Type = TransactionTypes.Payment;
        Created = DateTime.UtcNow;
        Detail = "";
        Trace = Hasher.GetHashString(trace);     
    }
    public Payment() { }
    
}
