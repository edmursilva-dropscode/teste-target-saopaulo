using System;
using System.Text;

namespace QuintaPergunta
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Exibir uma mensagem para o usuário
                Console.Clear(); // Limpar o console para uma nova entrada
                Console.WriteLine("Digite uma string para inverter (ou pressione ESC para sair):");

                // Ler a string do usuário
                string input = LerEntrada();

                // Verificar se a string é null (o que significa que o usuário pressionou ESC)
                if (input == null)
                {
                    break; // Sai do loop e encerra o programa
                }

                // Inverter as letras de cada palavra
                string resultado = InverterLetrasEmPalavras(input);

                // Exibir o resultado
                Console.WriteLine($"\nResultado: {resultado}");

                // Informar ao usuário sobre a opção de sair
                Console.WriteLine("\nPressione ESC para sair ou qualquer outra tecla para continuar...");

                // Aguarda o usuário pressionar uma tecla
                var tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.Escape)
                {
                    break; // Sai do loop e encerra o programa
                }
            }
        }

        static string LerEntrada()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                // Verifica se uma tecla está disponível
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);

                    // Se a tecla for ESC, retorna null para indicar saída
                    if (tecla.Key == ConsoleKey.Escape)
                    {
                        return null;
                    }
                    // Se a tecla for ENTER, finaliza a entrada
                    else if (tecla.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    // Se a tecla for uma tecla imprimível, adiciona ao StringBuilder
                    else if (tecla.KeyChar >= 32 && tecla.KeyChar <= 126)
                    {
                        sb.Append(tecla.KeyChar);
                        Console.Write(tecla.KeyChar); // Exibir caractere digitado
                    }
                }
            }
            return sb.ToString();
        }

        static string InverterLetrasEmPalavras(string str)
        {
            // Dividir a string em palavras usando espaço como delimitador
            string[] palavras = str.Split(' ');

            // Inverter cada palavra
            for (int i = 0; i < palavras.Length; i++)
            {
                char[] caracteres = palavras[i].ToCharArray();
                Array.Reverse(caracteres);
                palavras[i] = new string(caracteres);
            }

            // Reunir as palavras de volta em uma única string
            return string.Join(" ", palavras);
        }
    }
}

