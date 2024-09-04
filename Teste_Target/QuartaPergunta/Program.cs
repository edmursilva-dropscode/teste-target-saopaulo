using System;
using System.Collections.Generic;

namespace QuartaPergunta
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                // Faturamento por estado
                var faturamentos = new Dictionary<string, double>
                {
                    { "SP", 67836.43 },
                    { "RJ", 36678.66 },
                    { "MG", 29229.88 },
                    { "ES", 27165.48 },
                    { "Outros", 19849.53 }
                };

                // Calcular o valor total mensal
                double totalFaturamento = 0;
                foreach (var valor in faturamentos.Values)
                {
                    totalFaturamento += valor;
                }

                // Calcular e exibir o percentual de representação
                Console.WriteLine("Percentual de representação de cada estado:");
                foreach (var estado in faturamentos)
                {
                    double percentual = (estado.Value / totalFaturamento) * 100;
                    Console.WriteLine($"{estado.Key}: {percentual:F2}%");
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar ou ESC para sair...");

                // Aguarda o usuário pressionar uma tecla e verifica se é ESC
                var teclaFinal = Console.ReadKey(true).Key;
                if (teclaFinal == ConsoleKey.Escape)
                {
                    break; // Sai do loop principal e encerra o programa
                }

            }
        }
    }
}

