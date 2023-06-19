using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraProfessor.Model
{
    public class Professor
    {
        public string Nome { get; set; }
        public string Regime { get; set; }
        public double SalarioMensal { get; set; }
        public int HorasTrabalhadas { get; set; }
        public double ValorHora { get; set; }
        public double ValorContrato { get; set; }
        public double ValorReceber { get; set; }
    }
}
