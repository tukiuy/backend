using ProductsApi.Contracts.Dtos;
using ProductsApi.Contracts.Querys;
using MediatR;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompras.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public class ArticulosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly TelemetryClient _telemetryClient;

        public ArticulosController(IMediator mediator, TelemetryClient telemetryClient) 
        {
            _telemetryClient= telemetryClient;
            _mediator = mediator;
        }


        [HttpGet]
        [Route("v{version:apiVersion}/[controller]/ListarCatalogosPorIdEvento")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductDto>> ListarCatalogoPorIdEvento(Guid EventId)
        {
            try
            {
                var query = new GetCatalogueForEventQuery() { Id = EventId };
                var catalogos = await _mediator.Send(query);
                if (catalogos.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(catalogos);
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



    } 
}