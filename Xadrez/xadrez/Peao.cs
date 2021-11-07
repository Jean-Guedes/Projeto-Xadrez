using Jogo;

namespace Xadrez
{
    /// <summary>Peça Peão do Xadrez.</summary>
    class Peao : Peca
    {
        /// <summary>Partida do jogo, para saber se o peão está vunéravel ao En Passat.</summary>
        private PartidaDeXadrez partida;

        /// <summary>Construtor da Classe Peão, herdando os valores de Calsse Peca.</summary>
        public Peao(Tabuleiro tabuleiroPeca, Cor corPeca, PartidaDeXadrez partida) : base(tabuleiroPeca, corPeca)
        {
            this.partida = partida;
        }

        /// <summary>Sobrecarga do Metodo ToString() para classe Cavalo.</summary>
        /// <returns>O valor string: "P".</returns>
        public override string ToString()
        {
            return "P";
        }

        /// <summary>Checa se exite um inimigo do peão na posição.</summary>
        /// <param name="pos">Posição do peão.</param>
        /// <returns>True se existir um inimigo, False se não.</returns>
        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = TabuleiroPeca.Peca(pos);
            return p != null && p.CorPeca != CorPeca;
        }

        /// <summary>Checa se a posição está livre.</summary>
        /// <param name="pos">Posição do peão.</param>
        /// <returns>True se estiver EstaLivre, False se não.</returns>
        private bool EstaLivre(Posicao pos)
        {
            return TabuleiroPeca.Peca(pos) == null;
        }

        /// <summary>Possiveis Movimentos da peça Cavalo.</summary>
        /// <returns>Valor False ou True para uma Matriz [].</returns>
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[TabuleiroPeca.Linhas, TabuleiroPeca.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (CorPeca == Cor.Branca)
            {
                pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna);
                if (TabuleiroPeca.PosicaoValida(pos) && EstaLivre(pos))
                    mat[pos.Linha, pos.Coluna] = true;
                pos.DefinirValores(PosicaoPeca.Linha - 2, PosicaoPeca.Coluna);
                Posicao p2 = new Posicao(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna);
                if (TabuleiroPeca.PosicaoValida(p2) && EstaLivre(p2) && TabuleiroPeca.PosicaoValida(pos) && EstaLivre(pos) && QteMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;
                pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna - 1);
                if (TabuleiroPeca.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;
                pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna + 1);
                if (TabuleiroPeca.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;
                //Jogada Especial En Passant
                if (PosicaoPeca.Linha == 3)
                {
                    Posicao esquerda = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
                    if (TabuleiroPeca.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && TabuleiroPeca.Peca(esquerda) == partida.VulneravelEnPassant)
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    Posicao direita = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
                    if (TabuleiroPeca.PosicaoValida(direita) && ExisteInimigo(direita) && TabuleiroPeca.Peca(direita) == partida.VulneravelEnPassant)
                        mat[direita.Linha - 1, direita.Coluna] = true;
                }
            }
            else
            {
                pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna);
                if (TabuleiroPeca.PosicaoValida(pos) && EstaLivre(pos))
                    mat[pos.Linha, pos.Coluna] = true;
                pos.DefinirValores(PosicaoPeca.Linha + 2, PosicaoPeca.Coluna);
                Posicao p2 = new Posicao(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna);
                if (TabuleiroPeca.PosicaoValida(p2) && EstaLivre(p2) && TabuleiroPeca.PosicaoValida(pos) && EstaLivre(pos) && QteMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;
                pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna - 1);
                if (TabuleiroPeca.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;
                pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna + 1);
                if (TabuleiroPeca.PosicaoValida(pos) && ExisteInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;
                //Jogada Especial En Passant
                if (PosicaoPeca.Linha == 4)
                {
                    Posicao esquerda = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
                    if (TabuleiroPeca.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && TabuleiroPeca.Peca(esquerda) == partida.VulneravelEnPassant)
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    Posicao direita = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
                    if (TabuleiroPeca.PosicaoValida(direita) && ExisteInimigo(direita) && TabuleiroPeca.Peca(direita) == partida.VulneravelEnPassant)
                        mat[direita.Linha + 1, direita.Coluna] = true;
                }
            }
            return mat;
        }
    }
}