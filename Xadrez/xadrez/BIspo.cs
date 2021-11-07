using Jogo;

namespace Xadrez
{
    /// <summary>Peça Bispo do Xadrez.</summary>
    class Bispo : Peca
    {
        /// <summary>Construtor da Classe Bispo, herdando os valores de Calsse Peca.</summary>
        public Bispo(Tabuleiro tabuleiroPeca, Cor corPeca) : base(tabuleiroPeca, corPeca) { }

        /// <summary>Sobrecarga do Metodo ToString() para classe Rei.</summary>
        /// <returns>O valor string: "B".</returns>
        public override string ToString()
        {
            return "B";
        }

        /// <summary>Possiveis Movimentos da peça Bispo.</summary>
        /// <returns>Valor False ou True para uma Matriz [].</returns>
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[TabuleiroPeca.Linhas, TabuleiroPeca.Colunas];
            Posicao pos = new Posicao(0, 0);

            //cima-esquerda
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna - 1);
            while (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabuleiroPeca.Peca(pos) != null && TabuleiroPeca.Peca(pos).CorPeca != CorPeca)
                    break;
                pos.Linha -= 1;
                pos.Coluna -= 1;
            }

            //cima-direita
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna + 1);
            while (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabuleiroPeca.Peca(pos) != null && TabuleiroPeca.Peca(pos).CorPeca != CorPeca)
                    break;
                pos.Linha -= 1;
                pos.Coluna += 1;
            }

            //baixo-esquerda
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna - 1);
            while (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabuleiroPeca.Peca(pos) != null && TabuleiroPeca.Peca(pos).CorPeca != CorPeca)
                    break;
                pos.Linha += 1;
                pos.Coluna -= 1;
            }

            //baixo- direita
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna + 1);
            while (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabuleiroPeca.Peca(pos) != null && TabuleiroPeca.Peca(pos).CorPeca != CorPeca)
                    break;
                pos.Linha += 1;
                pos.Coluna += 1;
            }

            return mat;
        }
    }
}