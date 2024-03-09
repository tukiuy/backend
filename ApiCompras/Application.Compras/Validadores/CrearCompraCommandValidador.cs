using Domain.Compras.Commands;
using FluentValidation;

namespace Application.Compras.Validadores
{
    public class CrearCompraCommandValidador : AbstractValidator<CrearCompraCommand>
    {
        public CrearCompraCommandValidador()
        {
            RuleFor(GenerarCompraRequest => GenerarCompraRequest.Sub).NotNull().NotEmpty();
            RuleFor(GenerarCompraRequest => GenerarCompraRequest.IdEvento).NotNull().GreaterThan(0);
            RuleFor(GenerarCompraRequest => GenerarCompraRequest.IdDispositivo).NotNull().NotEmpty();
            RuleFor(GenerarCompraRequest => GenerarCompraRequest.ArticulosComprados).NotEmpty();
            RuleFor(GenerarCompraRequest => GenerarCompraRequest.IdEvento).NotEmpty().GreaterThan(0);
            RuleFor(GenerarCompraRequest => GenerarCompraRequest.IdComercio).NotEmpty().GreaterThan(0);
        }

    }
}