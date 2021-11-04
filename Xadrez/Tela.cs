using System;
using tabuleiro;

namespace Xadrez
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                        Console.Write("- ");
                    else
                    {
                        Tela.imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(Convert.ToChar('a' + i) + " ");
            }

        }
        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }

        }
    }
}