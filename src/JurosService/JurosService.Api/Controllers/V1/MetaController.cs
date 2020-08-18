using System;
using JurosService.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace JurosService.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    public class MetaController : ApiControllerBase
    {
        /// <summary> Produz erro 400 - Bad Request </summary>
        [HttpGet("400")]
        [ProducesResponseType(Status400BadRequest)]
        public IActionResult Get400()
        {
            ModelState.AddModelError("campo1", "motivo1");
            ModelState.AddModelError("campo1", "motivo2");
            ModelState.AddModelError("campo2", "motivo1");

            return ValidationProblem();
        }

        /// <summary> Produz erro 404 - Not Found </summary>
        [HttpGet("404")]
        [ProducesResponseType(Status404NotFound)]
        public IActionResult Get404() => NotFound();

        /// <summary> Produz erro 500 - Internal Server Error </summary>
        [HttpGet("500")]
        [ProducesResponseType(Status500InternalServerError)]
        public IActionResult Get500() => throw new Exception("Erro gerado intencionalmente p/ teste");
    }
}
