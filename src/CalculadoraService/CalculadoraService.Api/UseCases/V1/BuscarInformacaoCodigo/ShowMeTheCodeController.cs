using System.Threading.Tasks;
using CalculadoraService.Api.UseCases.Core;
using CalculadoraService.Application.BuscarInformacaoCodigoUseCase;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace CalculadoraService.Api.UseCases.V1.BuscarInformacaoCodigo
{
    [ApiVersion("1.0")]
    public class ShowMeTheCodeController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(Status200OK)]
        public async Task<ActionResult<InformacaoCodigoDto>> BuscarInformacaoCodigo([FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new BuscarInformacaoCodigoQuery());

            return Ok(result);
        }
    }
}
