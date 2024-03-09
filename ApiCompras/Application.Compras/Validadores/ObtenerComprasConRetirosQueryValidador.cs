using Domain.Compras.Commands;
using DomainLayer.Compras.Querys;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Compras.Validadores
{
    public class ObtenerComprasConRetirosQueryValidador : AbstractValidator<ObtenerComprasConRetirosQuery>
    {
            public ObtenerComprasConRetirosQueryValidador()
            {
                RuleFor(ObtenerRetiradosQuery => ObtenerRetiradosQuery.IdDispositivo).NotEmpty().NotNull();
                RuleFor(ObtenerRetiradosQuery => ObtenerRetiradosQuery.idEvento).NotNull().GreaterThan(0);
            }

        
    }
}
