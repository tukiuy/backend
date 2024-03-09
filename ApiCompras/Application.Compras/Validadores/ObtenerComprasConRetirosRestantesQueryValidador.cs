using DomainLayer.Compras.Querys;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Compras.Validadores
{
    public class ObtenerComprasConRetirosRestantesQueryValidador : AbstractValidator<ObtenerComprasConRetirosRestantesQuery>
    {
        public ObtenerComprasConRetirosRestantesQueryValidador()
        {

            RuleFor(ObtenerSinRetirarQuery => ObtenerSinRetirarQuery.IdDispositivo).NotEmpty().NotNull();
            RuleFor(ObtenerSinRetirarQuery => ObtenerSinRetirarQuery.idEvento).NotNull().GreaterThan(0);

        }
    }
}
