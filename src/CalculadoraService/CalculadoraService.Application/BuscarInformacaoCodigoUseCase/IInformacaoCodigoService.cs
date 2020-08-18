using System;
using System.Threading;
using System.Threading.Tasks;

namespace CalculadoraService.Application.BuscarInformacaoCodigoUseCase
{
    public interface IInformacaoCodigoService
    {
        Task<Uri> GetRepositorioUrl(CancellationToken cancellationToken);
    }
}
