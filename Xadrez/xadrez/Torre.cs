using Jogo;

namespace Xadrez
{
    /// <summary>Peça Torre do Xadrez.</summary>
    class Torre : Peca
    {
        /// <summary>Construtor da Classe Torre, herdando os valores de Calsse Peca.</summary>
        public Torre(Tabuleiro tabuleiroPeca, Cor corPeca) : base(tabuleiroPeca, corPeca) { }

        /// <summary>Sobrecarga do Metodo ToString() para classe Rei.</summary>
        /// <returns>O valor string: "T".</returns>
        public override string ToString()
        {
            return "T";
        }

        /// <summary>Possiveis Movimentos da peça Torre.</summary>
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

            return mat;
        }
    }
}