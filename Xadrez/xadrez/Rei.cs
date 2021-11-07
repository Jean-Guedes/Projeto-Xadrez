using Jogo;

namespace Xadrez
{
    /// <summary>Peça Rei do Xadrez.</summary>
    class Rei : Peca
    {
        private PartidaDeXadrez Partida;

        /// <summary>Construtor da Classe Rei, herdando os valores de Calsse Peca.</summary>
        public Rei(Tabuleiro tabuleiroPeca, Cor corPeca, PartidaDeXadrez partida) : base(tabuleiroPeca, corPeca)
        {
            Partida = partida;
        }

        /// <summary>Sobrecarga do Metodo ToString() para classe Rei.</summary>
        /// <returns>O valor string: "R".</returns>
        public override string ToString()
        {
            return "R";
        }

        /// <summary>Validação se a Peça Torre pode realizar um Roque</summary>
        /// <param name="pos">Posição da peça.</param>
        /// <returns>True se a Torre pode realizar um Roque, False se não</returns>
        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = TabuleiroPeca.Peca(pos);
            return p != null && p is Torre && p.CorPeca == CorPeca && p.QteMovimentos == 0;
        }

        /// <summary>Possiveis Movimentos da peça Rei.</summary>
        /// <returns>Valor False ou True para uma Matriz [].</returns>
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[TabuleiroPeca.Linhas, TabuleiroPeca.Colunas];
            Posicao pos = new Posicao(0, 0);

            //cima
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna);
            if (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //baixo
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna);
            if (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //esquerda
            pos.DefinirValores(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
            if (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //direita
            pos.DefinirValores(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
            if (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //Diagonal Cima Esquerda
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna - 1);
            if (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //Diagonal Cima Direita
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna + 1);
            if (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //Diagonal Baixa Esquerda
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna - 1);
            if (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //Diagonal Baixa Direita
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna + 1);
            if (TabuleiroPeca.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //JOGADAS ESPECIAIS
            //Roque Pequeno e Grande
            if (QteMovimentos == 0 && !Partida.Xeque)
            {
                //Roque Pequeno
                Posicao posT1 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 3);
                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
                    Posicao p2 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 2);
                    if (TabuleiroPeca.Peca(p1) == null && TabuleiroPeca.Peca(p2) == null)
                        mat[PosicaoPeca.Linha, PosicaoPeca.Coluna + 2] = true;
                }
                //Roque Grande
                Posicao posT2 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 4);
                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
                    Posicao p2 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 2);
                    Posicao p3 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 3);
                    if (TabuleiroPeca.Peca(p1) == null && TabuleiroPeca.Peca(p2) == null && TabuleiroPeca.Peca(p3) == null)
                        mat[PosicaoPeca.Linha, PosicaoPeca.Coluna - 2] = true;
                }
            }
            return mat;
        }
    }
}