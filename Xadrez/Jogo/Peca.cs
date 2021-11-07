namespace Jogo
{
    /// <summary>Peça generica de um jogo.</summary>
    abstract class Peca
    {
        /// <summary>Posiçao da peça.</summary>
        public Posicao PosicaoPeca { get; set; }
        /// <summary>Cor da peça.</summary>
        public Cor CorPeca { get; protected set; }
        /// <summary>Quantidade de movimentos da peça.</summary>
        public int QteMovimentos { get; protected set; }
        /// <summary>Referencia da peça à classe Tabuleiro.</summary>
        public Tabuleiro TabuleiroPeca { get; protected set; }

        /// <summary>Contrutor da classe Peça.</summary>
        /// <param name="tabuleiroPeca">Tabuleiro que está a peça.</param>
        /// <param name="corPeca">Cor da peça.</param>
        public Peca(Tabuleiro tabuleiroPeca, Cor corPeca)
        {
            PosicaoPeca = null;
            TabuleiroPeca = tabuleiroPeca;
            CorPeca = corPeca;
            QteMovimentos = 0;
        }

        /// <summary>Validação se a peça pode mover-se.</summary>
        /// <param name="pos">Posição atual do Bispo.</param>
        /// <returns>Um valor Peca null ou valor Peca.CorPeca.</returns>
        protected bool PodeMover(Posicao pos)
        {
            Peca peca = TabuleiroPeca.Peca(pos);
            return peca == null || peca.CorPeca != CorPeca;
        }

        /// <summary>Icrementa a quantidade de movimentos.</summary>
        public void IncrementarQteMovimento()
        {
            QteMovimentos++;
        }

        /// <summary>Reduiz a quantidade de movimento.</summary>
        public void DecrementarQteMovimentos()
        {
            QteMovimentos--;
        }

        /// <summary>Checa que existe movimentos possiveis para a peça.</summary>
        /// <returns>True se existe movimentos, False se não.</returns>
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < TabuleiroPeca.Linhas; i++)
            {
                for (int j = 0; j < TabuleiroPeca.Colunas; j++)
                {
                    if (mat[i, j])
                        return true;
                }
            }
            return false;
        }

        /// <summary>Valida se o movimento é possivel.</summary>
        /// <param name="pos">Posição de origem e destino.</param>
        /// <returns>True se o movimento é possivel, False se não.</returns>
        public bool PossivelMovimento(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        /// <summary>Método abstrato de movimentos.</summary>
        public abstract bool[,] MovimentosPossiveis();

    }
}