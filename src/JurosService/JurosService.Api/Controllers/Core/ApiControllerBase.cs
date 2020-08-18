using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace JurosService.Api.Controllers.Core
{
    /// <summary> Classe base p/ um API controller versionado </summary>
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json", "application/problem+json")]
    [ProducesResponseType(Status500InternalServerError)]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
