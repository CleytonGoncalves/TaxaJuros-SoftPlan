using System.ComponentModel.DataAnnotations;

namespace CalculadoraService.Api.UseCases.V1.CalcularTaxaJuros
{
    public class CalcularTaxaJurosRequest
    {
        [Required]
        [Range(0, int.MaxValue)]
        public decimal ValorInicial { get; set;  }

        [Required]
        [Range(0, short.MaxValue)]
        public int Meses { get; set; }
    }
}
