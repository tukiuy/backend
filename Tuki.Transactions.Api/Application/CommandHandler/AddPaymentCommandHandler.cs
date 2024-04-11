using MediatR;
using Tuki.Common.Constants;
using Tuki.Transactions.Api.Contracts.Commands;
using Tuki.Transactions.Api.Contracts.Dto;
using Tuki.Transactions.Api.Contracts.Models;
using Tuki.Transactions.Api.Infrastructure.Context;

namespace Tuki.Transactions.Api.Application.CommandHandler;

public class AddPaymentCommandHandler(TransactionsContext context)
    : IRequestHandler<CreatePaymentCommand, Guid>
{
    private readonly TransactionsContext _context = context;

    public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        Payment payment = new(request.Id, request.Status, request.User, request.EventId);
        await _context.Payment.AddAsync(payment, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return payment.TransactionId;
    }
}
