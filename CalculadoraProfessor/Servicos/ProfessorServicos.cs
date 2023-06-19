using CalculadoraProfessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraProfessor.Servicos
{
    public class ProfessorServicos
    {

        public static async Task IniciarProcesso()
        {
            Professor professor = new Professor();

            Console.Write("Digite o nome do professor: ");
            professor.Nome = Console.ReadLine();

            Console.WriteLine("Selecione o regime de pagamento:");
            Console.WriteLine("1. CLT");
            Console.WriteLine("2. Horista");
            Console.WriteLine("3. PJ");
            Console.Write("Opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            await ObterValorSalario(opcao, professor);

            await CalcularValorReceber(professor);

            Console.WriteLine("Nome do professor: " + professor.Nome);
            Console.WriteLine("Valor a receber: R$ " + professor.ValorReceber);
            Console.WriteLine("Deseja calcular novamente? sim / não ");
            await ValidarRetorno();

        }
        private static async Task ValidarRetorno()
        {
            string opcaovoltar = Console.ReadLine().ToString();
            if (opcaovoltar.ToLower() != "sim")
            {
                Environment.Exit(0);
                
            }
            Console.Clear();
            await IniciarProcesso();
        }
        private static async Task ObterValorSalario(int opcao, Professor professor)
        {
            switch (opcao)
            {

                case 1:
                    professor.Regime = "CLT";
                    Console.Write("Digite o salário mensal do professor: ");
                    professor.SalarioMensal = Convert.ToDouble(Console.ReadLine());
                    break;
                case 2:
                    professor.Regime = "Horista";
                    Console.Write("Digite o número de horas trabalhadas: ");
                    professor.HorasTrabalhadas = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Digite o valor da hora de trabalho: ");
                    professor.ValorHora = Convert.ToDouble(Console.ReadLine());
                    break;
                case 3:
                    professor.Regime = "PJ";
                    Console.Write("Digite o valor do contrato do professor: ");
                    professor.ValorContrato = Convert.ToDouble(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    return;
            }
        }
        private static async Task CalcularValorReceber(Professor professor)
        {
            switch (professor.Regime)
            {
                case "CLT":
                    professor.ValorReceber = professor.SalarioMensal;
                    break;
                case "Horista":
                    professor.ValorReceber = professor.HorasTrabalhadas * professor.ValorHora;
                    break;
                case "PJ":
                    professor.ValorReceber = professor.ValorContrato;
                    break;
                default:
                    Console.WriteLine("Regime de pagamento inválido.");
                    break;
            }
        }
    }
}
