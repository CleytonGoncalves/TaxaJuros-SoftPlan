namespace CalculadoraService.Application.BuscarInformacaoCodigoUseCase
{
    public class InformacaoCodigoDto
    {
        public string Url { get; }

        public InformacaoCodigoDto(string url)
        {
            Url = url;
        }
    }
}
