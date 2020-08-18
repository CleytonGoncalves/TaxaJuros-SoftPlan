using System.Threading.Tasks;
using JurosService.Api.Controllers.Core;
using JurosService.Api.Domain.TaxasJuros;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace JurosService.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    public class TaxaJurosController : ApiControllerBase
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public TaxaJurosController(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        /// <summary> Busca a taxa de juros atual </summary>
        [HttpGet]
        [ProducesResponseType(Status200OK)]
        public async Task<ActionResult<decimal>> GetTaxaJuros()
        {
            return Ok(await _taxaJurosService.GetTaxaAtual());
        }
    }
}
