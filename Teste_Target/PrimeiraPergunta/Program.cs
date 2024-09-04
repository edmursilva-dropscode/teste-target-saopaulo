using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiraPergunta
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Valores padrão
            int valorPadraoIndice = 13;
            int valorPadraoK = 0;

            while (true)
            {
                // Limpa a tela
                Console.Clear();

                // Entrada para o valor de INDICE com valor padrão
                Console.WriteLine($"Valor de INDICE (padrão é {valorPadraoIndice}):");
                int indice = valorPadraoIndice;

                // Entrada para o valor de K com valor padrão
                Console.WriteLine($"Valor de K (padrão é {valorPadraoK}):");
                int k = valorPadraoK;

                // Calcular SOMA
                int soma = 0;
                int kAtual = k;

                while (kAtual < indice)
                {
                    kAtual = kAtual + 1;
                    soma = soma + kAtual;
                }

                // Exibindo o resultado
                Console.WriteLine($"O valor final de SOMA é: {soma}");

                Console.WriteLine("Pressione qualquer tecla para continuar ou ESC para sair...");

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

