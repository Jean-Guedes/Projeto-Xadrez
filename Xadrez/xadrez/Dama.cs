using Jogo;

namespace Xadrez
{
    /// <summary>Peça Dama do Xadrez.</summary>
    class Dama : Peca
    {
        /// <summary>Construtor da Classe Dama, herdando os valores de Calsse Peca.</summary>
        public Dama(Tabuleiro tabuleiroPeca, Cor corPeca) : base(tabuleiroPeca, corPeca) { }

        /// <summary>Sobrecarga do Metodo ToString() para classe Rei.</summary>
        /// <returns>O valor string: "D".</returns>
        public override string ToString()
        {
            return "D";
        }

        /// <summary>Possiveis Movimentos da peça Dama.</summary>
        /// <returns>Valor False ou True para uma Matriz [].</returns>
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[TabuleiroPeca.Linhas, TabuleiroPeca.Colunas];
            Posicao pos = new Posicao(0, 0);

            //cima
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna);
            while (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabuleiroPeca.Peca(pos) != null && TabuleiroPeca.Peca(pos).CorPeca != CorPeca)
                    break;
                pos.Linha -= 1;
            }

            //baixo
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna);
            while (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabuleiroPeca.Peca(pos) != null && TabuleiroPeca.Peca(pos).CorPeca != CorPeca)
                    break;
                pos.Linha += 1;
            }

            //esquerda
            pos.DefinirValores(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
            while (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabuleiroPeca.Peca(pos) != null && TabuleiroPeca.Peca(pos).CorPeca != CorPeca)
                    break;
                pos.Coluna -= 1;
            }

            //direita
            pos.DefinirValores(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
            while (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (TabuleiroPeca.Peca(pos) != null && TabuleiroPeca.Peca(pos).CorPeca != CorPeca)
                    break;
                pos.Coluna += 1;
            }

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