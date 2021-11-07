using Jogo;
using System;
using System.Collections.Generic;

namespace Xadrez
{
    /// <summary>Tela de Xadrez no Console.</summary>
    class Tela
    {
        /// <summary>Imprime a tela da partida de Xadrez.</summary>
        /// <param name="partida">Partida atual de Xadrez.</param>
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            if (!partida.Terminada)
            {
                Console.WriteLine("Aguradando jogada: " + partida.JogadorAtual);
                if (partida.Xeque)
                    Console.WriteLine("XEQUE!");
            }
            else
            {
                System.Console.WriteLine("XEQUEMATE!");
                System.Console.WriteLine("Vencedor foi " + partida.JogadorAtual);
            }
            Console.WriteLine();
        }

        /// <summary>Imprime as peças capturadas de todos os jogadores.</summary>
        /// <param name="partida">Partida atual.</param>
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        /// <summary>Imprime as peças capturadas de um jogados.</summary>
        /// <param name="conjunto">Conjunto de peças.</param>
        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        /// <summary>Imprime o Tabuleiro de Xadrez.</summary>
        /// <param name="tab">tabuleiro de um jogo.</param>
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(Convert.ToChar('a' + i) + " ");
            }
            Console.WriteLine("\n");
        }

        /// <summary>Imprime as possiveis jogadas em um tabuleiro de Xadrez.</summary>
        /// <param name="tab">Tabuleiro de um jogo.</param>
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOriginal;
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(Convert.ToChar('a' + i) + " ");
            }
            Console.BackgroundColor = fundoOriginal;
            Console.WriteLine("\n");
        }

        /// <summary>Ler as a posição de uma peça no jogo de Xadrez.</summary>
        /// <returns>Posição de uma peça no jogo de Xadrez na Classe PosiçãoXadrez.</returns>
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        /// <summary>Imprime as peças de um jogo de Xadrez.</summary>
        /// <param name="peca" >Uma peça de jogo.</param>
        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
                Console.Write("- ");
            else
            {
                if (peca.CorPeca == Cor.Branca)
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
                Console.Write(" ");
            }

        }
    }
}