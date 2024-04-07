

using ApplicationLayer.Compras.Validadores;
using Domain.Compras.Commands;
using DomainLayer.Compras.Dtos;
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
    public class ComprasController : ControllerBase
    {
        private readonly IValidator<CrearCompraCommand> _validatorCrearCompra;
        private readonly IValidator<ObtenerComprasConRetirosQuery> _validatorObtenerComprasConRetiros;
        private readonly IValidator<ObtenerComprasConRetirosRestantesQuery> _validatorObtenerComprasConRetirosRestantes;
        private readonly IMediator _mediator;
        private readonly TelemetryClient _telemetryClient;

        public ComprasController(IValidator<CrearCompraCommand> validatorCrearCompra,
            IValidator<ObtenerComprasConRetirosQuery> validatorObtenerRetirados, 
            IValidator<ObtenerComprasConRetirosRestantesQuery> validatorObtenerComprasConRetirosRestantes, 
            IMediator mediator, TelemetryClient telemetryClient)
        {
            _validatorCrearCompra = validatorCrearCompra;
            _validatorObtenerComprasConRetiros = validatorObtenerRetirados;
            _validatorObtenerComprasConRetirosRestantes = validatorObtenerComprasConRetirosRestantes;
            _mediator = mediator;
            _telemetryClient = telemetryClient;
        }

        [HttpPost]
        [Route("v{version:apiVersion}/[controller]/CrearCompra")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<ActionResult> CrearCompra(CrearCompraCommand generarCompraCommand)
        {
            try
            {
                ValidationResult result = await _validatorCrearCompra.ValidateAsync(generarCompraCommand);

                if (!result.IsValid)
                {

                    return new BadRequestObjectResult(result.Errors);

                }
                int CompraId = await _mediator.Send(generarCompraCommand);
                return Created("Created",new { CompraId = CompraId });               
            }
            catch(Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }     
        }

        [HttpPost]
        [Route("v{version:apiVersion}/[controller]/ObtenerComprasConRetiros")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<ActionResult<ComprasConRetiros>> ObtenerComprasConRetiros(ObtenerComprasConRetirosQuery obtenerRetiradosQuery)
        {
            try
            {
                ValidationResult result = await _validatorObtenerComprasConRetiros.ValidateAsync(obtenerRetiradosQuery);

                if (!result.IsValid)
                {
                    return new BadRequestObjectResult(result.Errors);
                }
                var artRetirados = await _mediator.Send(obtenerRetiradosQuery);
                return Ok(artRetirados);
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("v{version:apiVersion}/[controller]/ObtenerComprasConRetirosRestantes")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<ActionResult<ComprasRetirosRestantes>> ObtenerComprasConRetirosRestantes(ObtenerComprasConRetirosRestantesQuery obtenerSinRetirarQuery)
        {
            try
            {
                ValidationResult result = await _validatorObtenerComprasConRetirosRestantes.ValidateAsync(obtenerSinRetirarQuery);

                if (!result.IsValid)
                {

                    return new BadRequestObjectResult(result.Errors);

                }
                var artSinRetirar = await _mediator.Send(obtenerSinRetirarQuery);
                return Ok(artSinRetirar);
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("v{version:apiVersion}/[controller]/{idEvento}/{device}")]
        [ProducesResponseType(typeof(List<CompraCompletaDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CompraCompletaDto>>> ObtenerCompras(
            int idEvento, string device)
        {
            try
            {
                var query =  new ObtenerComprasQuery 
                {
                    IdEvento = idEvento,
                    IdDispositivo = device
                };

                var articulos = await _mediator.Send(query);
                return Ok(articulos);
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    } 
}