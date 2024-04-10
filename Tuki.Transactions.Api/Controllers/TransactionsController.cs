using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tuki.Transactions.Api.Contracts.Commands;

namespace Tuki.Transactions.Api.Controllers
{
    [ApiController]
    public class TransactionsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentCommand createPaymentCommand)
        {
            var res = await _mediator.Send(createPaymentCommand);
            return Ok(res);
        }
    }
}
