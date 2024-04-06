using ProductsApi.Contracts.Dtos;
using ProductsApi.Contracts.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ProductsController(IMediator mediator, ILogger<ProductsController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<ProductsController> logger = logger;

        [HttpGet]
        public async Task<ActionResult<ProductDto>> ListarCatalogoPorIdEvento(Guid EventId)
        {
            try
            {
                var query = new GetCatalogQuery() { EventId = EventId };
                var catalogos = await _mediator.Send(query);
                if (catalogos.Any())
                {
                    return Ok(catalogos);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(message: "Some exception was thrown and not captured." ,exception: ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    } 
}