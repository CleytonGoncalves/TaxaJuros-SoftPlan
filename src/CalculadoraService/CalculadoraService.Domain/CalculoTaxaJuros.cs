using System;
using System.Globalization;

namespace CalculadoraService.Domain
{
    public class CalculoTaxaJuros
    {
        public decimal ValorInicial { get; }
        public int TempoMeses { get; }
        public decimal TaxaJuros { get; }

        public decimal Resultado { get; }

        public CalculoTaxaJuros(decimal valorInicial, int tempoMeses, decimal taxaJuros)
        {
            ValorInicial = valorInicial;
            TempoMeses = tempoMeses;
            TaxaJuros = taxaJuros;

            var taxaCompostaNoPeriodo = (decimal) Math.Pow(1 + (double) taxaJuros, tempoMeses);
            Resultado = valorInicial * taxaCompostaNoPeriodo;
        }

        public string GetResultadoFormatted(int decimalPlaces, CultureInfo? culture = null)
        {
            return Truncate(Resultado, decimalPlaces).ToString(culture);
        }

        private static decimal Truncate(decimal value, int decimalPlaces)
        {
            /*
             * Converte para decimal p/ não perder precisão ao multiplicar/dividir. Caso contrário, por exemplo,
             * 5.02 truncado vira 5.01, pois 5.02 * 100 == 501.99999999999994.
             */
            var power = (decimal) Math.Pow(10, decimalPlaces);

            return Math.Truncate(value * power) / power;
        }
    }
}
