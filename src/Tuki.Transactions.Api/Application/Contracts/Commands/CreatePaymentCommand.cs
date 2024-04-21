using MediatR;

namespace Tuki.Transactions.Api.Application.Contracts.Commands;

public class CreatePaymentCommand(Guid Id, string Status, Guid User, Guid EventId) : IRequest<Guid>
{
    public Guid Id { get; } = Id;
    public Guid User { get; } = User;
    public Guid EventId { get; } = EventId;
    public string Status { get; } = Status;
}
