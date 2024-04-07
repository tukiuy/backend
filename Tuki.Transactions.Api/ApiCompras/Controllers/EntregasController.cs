

using ApplicationLayer.Compras.Validadores;
using Domain.Compras.Commands;
using DomainLayer.Compras.Dtos;
using DomainLayer.Compras.Dtos.Respuestas;
using DomainLayer.Compras.Querys;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiCompras.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public class EntregasController : ControllerBase
    {
        private readonly IValidator<CrearEntregaCommand> _validatorCrearCompra;
        private readonly IMediator _mediator;
        private readonly TelemetryClient _telemetryClient;

        public EntregasController(IValidator<CrearEntregaCommand> validatorCrearCompra,
            IMediator mediator, TelemetryClient telemetryClient)
        {
            _validatorCrearCompra = validatorCrearCompra;

            _mediator = mediator;
            _telemetryClient = telemetryClient;
        }

        [HttpPost]
        [Route("v{version:apiVersion}/[controller]/CrearEntrega")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<ActionResult> CrearEntrega(CrearEntregaCommand crearEntregaCommand)
        {
            try
            {
                ValidationResult result = await _validatorCrearCompra.ValidateAsync(crearEntregaCommand);

                if (!result.IsValid)
                {

                    return new BadRequestObjectResult(result.Errors);

                }
                CrearEntregaRespuesta entregaResponse = await _mediator.Send(crearEntregaCommand);
                return Ok(entregaResponse);               
            }
            catch(Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }     
        }



    } 
}