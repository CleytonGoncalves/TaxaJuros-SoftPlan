using System.Threading.Tasks;
using CalculadoraService.Api.UseCases.Core;
using CalculadoraService.Application.CalcularTaxaJurosUseCase;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace CalculadoraService.Api.UseCases.V1.CalcularTaxaJuros
{
    [ApiVersion("1.0")]
    public class CalculaJurosController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<ActionResult<CalculoTaxaJurosDto>> CalcularJuros([FromServices] IMediator mediator,
            [FromQuery] CalcularTaxaJurosRequest request)
        {
            var command = new CalcularTaxaJurosCommand(request.ValorInicial, request.Meses);

            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}
