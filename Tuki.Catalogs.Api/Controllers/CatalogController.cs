using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tuki.Catalogs.Api.Contracts.Dtos;
using Tuki.Catalogs.Api.Contracts.Querys;

namespace Tuki.Catalogs.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class CatalogController(IMediator mediator, ILogger<CatalogController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<CatalogController> logger = logger;

        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult<ProductDto>> ListarCatalogoPorIdEvento(Guid EventId)
        {
            try
            {
                var query = new GetEventCatalogQuery() { EventId = EventId };
                var catalogos = await _mediator.Send(query);
                if (catalogos.Any())
                {
                    return Ok(catalogos);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(message: "Some exception was thrown and not captured.", exception: ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}