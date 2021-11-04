using System;
using tabuleiro;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);
            Posicao P;

            P = new Posicao(3,4);

            Console.WriteLine(tab);
        }
    }
}
