using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaPergunta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite um número para verificar se ele pertence à sequência de Fibonacci ou pressione ESC para sair:");

                // Variável para armazenar a entrada do usuário
                string input = "";

                // Leitura das teclas uma por uma
                while (true)
                {
                    // Lê a tecla pressionada sem exibi-la no console
                    var tecla = Console.ReadKey(intercept: true);

                    // Se a tecla ESC for pressionada, sai do programa
                    if (tecla.Key == ConsoleKey.Escape)
                    {
                        return; // Sai do método Main, encerrando o programa
                    }

                    // Se Enter for pressionado, interrompe a leitura
                    if (tecla.Key == ConsoleKey.Enter)
                    {
                        break; // Sai do loop de leitura de input
                    }

                    // Adiciona a tecla pressionada ao input se for um número ou backspace
                    if (char.IsDigit(tecla.KeyChar) || tecla.Key == ConsoleKey.Backspace)
                    {
                        if (tecla.Key == ConsoleKey.Backspace && input.Length > 0)
                        {
                            // Remove o último caractere se for backspace
                            input = input.Substring(0, input.Length - 1);
                            Console.Write("\b \b"); // Remove o último caractere visualmente
                        }
                        else if (char.IsDigit(tecla.KeyChar))
                        {
                            input += tecla.KeyChar; // Adiciona o caractere ao input
                            Console.Write(tecla.KeyChar); // Exibe o caractere no console
                        }
                    }
                }

                // Verifica se a entrada é um número válido
                if (int.TryParse(input, out int numero))
                {
                    // Verifica se o número está na sequência de Fibonacci
                    if (PertenceFibonacci(numero))
                    {
                        Console.WriteLine($"\nO número {numero} pertence à sequência de Fibonacci.");
                    }
                    else
                    {
                        Console.WriteLine($"\nO número {numero} não pertence à sequência de Fibonacci.");
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida. Por favor, digite um número inteiro.");
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

        // Método para verificar se um número pertence à sequência de Fibonacci
        static bool PertenceFibonacci(int numero)
        {
            // Os primeiros números da sequência de Fibonacci
            int a = 0;
            int b = 1;

            // Se o número informado for 0 ou 1, ele pertence à sequência de Fibonacci
            if (numero == a || numero == b)
            {
                return true;
            }

            int proximo = a + b;

            // Itera até que o próximo número na sequência de Fibonacci seja maior que o número informado
            while (proximo <= numero)
            {
                if (proximo == numero)
                {
                    return true; // O número pertence à sequência de Fibonacci
                }

                a = b;
                b = proximo;
                proximo = a + b;
            }

            return false; // O número não pertence à sequência de Fibonacci
        }

    }
}

