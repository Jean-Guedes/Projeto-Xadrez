using System;
using tabuleiro;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));

                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 5));
                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 6));
                tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(3, 4));



                Tela.imprimirTabuleiro(tab);

                Console.ReadLine();
            }
            catch (TabuleiroException e)
            {

                Console.WriteLine(e.Message);
            }

        }

    }
}