using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraDePreco
{
    public class Calcular
    {
        public double Valor { get; set; }
        public double Margem { get; set; }
        public double Imposto { get; set; }
        public double ValorFinal { get; set; }

        public double Calculo()
        {
            ValorFinal = (Valor / (1 - Margem / 100)) * (1 + Imposto/100);
            return ValorFinal;
        }
    }
}