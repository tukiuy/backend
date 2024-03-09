using Domain.Compras.Commands;
using FluentValidation;

namespace Application.Compras.Validadores
{
    public class CrearEntregaCommandValidador : AbstractValidator<CrearEntregaCommand>
    {
        public CrearEntregaCommandValidador()
        {
            RuleFor(CrearEntregaReq => CrearEntregaReq.Articulos).NotNull().NotEmpty();
            RuleFor(CrearEntregaReq => CrearEntregaReq.IdCompra).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(CrearEntregaReq => CrearEntregaReq.IdPuntoDeEntrega).NotNull().NotEmpty().GreaterThan(0);

        }

    }
}