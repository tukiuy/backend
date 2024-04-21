using MediatR;
using Tuki.Transactions.Api.Application.Contracts.Commands;
using Tuki.Transactions.Api.Infrastructure.Context;
using Tuki.Transactions.Api.Models;

namespace Tuki.Transactions.Api.Application.CommandHandler;

public class AddPaymentCommandHandler(TransactionsContext context)
    : IRequestHandler<CreatePaymentCommand, Guid>
{
    private readonly TransactionsContext _context = context;

    public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        Payment payment = new(request.Id, request.Status, request.User, request.EventId);
        await _context.Payments.AddAsync(payment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return payment.TransactionId;
    }
}
