using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TerceiraPergunta
{
    class Program
    {
        public class Faturamento
        {
            public int Dia { get; set; }
            public double ValorFaturamento { get; set; }
            public string Diasemana { get; set; }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                // Definir o caminho do arquivo JSON no diretório 'Faturamento'
                string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string filePath = Path.Combine(projectDirectory, "Faturamento", "faturamento_novembro.json");

                // Verificar se o arquivo realmente existe
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Arquivo não encontrado: {filePath}");
                    return;
                }

                var faturamentos = CarregarDados(filePath);

                if (faturamentos == null || faturamentos.Count == 0)
                {
                    Console.WriteLine("Nenhum dado disponível para processamento.");
                    return;
                }

                // Calcular menor e maior valor de faturamento
                double menorFaturamento = double.MaxValue;
                double maiorFaturamento = double.MinValue;

                double somaFaturamento = 0;
                int diasComFaturamento = 0;
                int diasUteisTotal = 0;

                foreach (var item in faturamentos)
                {
                    if (item.ValorFaturamento > 0)
                    {
                        // Atualizar menor e maior valor de faturamento
                        if (item.ValorFaturamento < menorFaturamento) menorFaturamento = item.ValorFaturamento;
                        if (item.ValorFaturamento > maiorFaturamento) maiorFaturamento = item.ValorFaturamento;

                        // Somar faturamento para cálculo da média
                        somaFaturamento += item.ValorFaturamento;
                        diasComFaturamento++;
                    }

                    // Contar todos os dias úteis
                    if (!item.Diasemana.Contains("feriado") && !item.Diasemana.Contains("sábado") && !item.Diasemana.Contains("domingo"))
                    {
                        diasUteisTotal++;
                    }
                }

                // Verificar se há faturamento para evitar divisão por zero
                if (diasUteisTotal == 0)
                {
                    Console.WriteLine("Não há dias úteis válidos para calcular a média.");
                    Console.WriteLine("\nPressione qualquer tecla para continuar ou ESC para sair...");

                    // Aguarda o usuário pressionar uma tecla e verifica se é ESC
                    var teclaFinall = Console.ReadKey(true).Key;
                    if (teclaFinall == ConsoleKey.Escape)
                    {
                        break; // Sai do loop principal e encerra o programa
                    }
                }

                // Calcular média mensal
                double mediaMensal = somaFaturamento / diasComFaturamento;

                // Contar dias com faturamento superior à média
                int diasAcimaMedia = 0;
                foreach (var item in faturamentos)
                {
                    if (item.ValorFaturamento > mediaMensal && !item.Diasemana.Contains("feriado") && !item.Diasemana.Contains("sábado") && !item.Diasemana.Contains("domingo"))
                    {
                        diasAcimaMedia++;
                    }
                }

                // Exibir resultados
                Console.WriteLine($"Menor valor de faturamento: {menorFaturamento:C}");
                Console.WriteLine($"Maior valor de faturamento: {maiorFaturamento:C}");
                Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaMedia}");

                Console.WriteLine("\nPressione qualquer tecla para continuar ou ESC para sair...");

                // Aguarda o usuário pressionar uma tecla e verifica se é ESC
                var teclaFinal = Console.ReadKey(true).Key;
                if (teclaFinal == ConsoleKey.Escape)
                {
                    break; // Sai do loop principal e encerra o programa
                }
            }
        }

        static List<Faturamento> CarregarDados(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                var faturamentos = JsonConvert.DeserializeObject<List<Faturamento>>(json);
                return faturamentos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar o arquivo JSON: {ex.Message}");
                return null;
            }
        }
    }
}

