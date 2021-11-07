namespace Jogo
{
    /// <summary>Tabuleiro Generico com linhas e colunas.</summary>
    class Tabuleiro
    {
        /// <summary>Colunas de um tabuleiro.</summary>
        public int Colunas { get; set; }
        /// <summary>Linhas de um tabuleiro.</summary>
        public int Linhas { get; set; }
        /// <summary>Peças no tabuleiro.</summary>
        private Peca[,] pecas;

        /// <summary>Construtor da Classe Tabuleiro recebendo linhas e colunas.</summary>
        /// <param name="linha">linhas de um tabuleiro.</param>
        /// <param name="coluna">colunas de um tabuleiro.</param>
        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        /// <summary>Informa a posição de uma peça no tabuleiro, atraves de valores inteiros.</summary>
        /// <param name="linha">Valor inteiro de uma linha no tabuleiro.</param>
        /// <param name="coluna">Valor inteiro de uma coluna no tabuleiro.</param>
        /// <returns>Retorna o valor como: Peca[linha,coluna].</returns>
        public Peca Peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        /// <summary>Informa a posição de uma peça no tabuleiro, atraves da classe Posição.</summary>
        /// <param name="pos">Valor de um uma posição.</param>
        /// <returns>Retorna o valor como: Peca[Linha,Coluna].</returns>
        public Peca Peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        /// <summary>Informa se a peça exite na posição.</summary>
        /// <param name="pos">Valor de um uma posição.</param>
        /// <returns>Retorna o True se exite peça na posição, se não False.</returns>
        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

        /// <summary>Coloca uma peça no tabuleiro.</summary>
        /// <param name="p">Peça a ser colocada no tabuleiro.</param>
        /// <param name="pos">Posição a da peça a ser colocada.</param>
        public void ColocarPeca(Peca peca, Posicao pos)
        {
            if (ExistePeca(pos))
                throw new TabuleiroException("Já existe uma peça nessa posição");
            pecas[pos.Linha, pos.Coluna] = peca;
            peca.PosicaoPeca = pos;
        }

        /// <summary>Reira uma peça no tabuleiro.</summary>
        /// <param name="p">Peça a ser retirada do tabuleiro.</param>
        /// <param name="pos">Posição a da peça a ser retirada.</param>
        public Peca RetirarPeca(Posicao pos)
        {
            if (Peca(pos) == null)
                return null;
            Peca aux = Peca(pos);
            aux.PosicaoPeca = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        /// <summary>Reira uma peça no tabuleiro.</summary>
        /// <param name="p">Peça a ser retirada do tabuleiro.</param>
        /// <param name="pos">Posição a da peça a ser retirada.</param>
        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
                return false;
            return true;
        }

        /// <summary>Reira uma peça no tabuleiro.</summary>
        /// <param name="p">Peça a ser retirada do tabuleiro.</param>
        /// <param name="pos">Posição a da peça a ser retirada.</param>
        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
                throw new TabuleiroException("Posição Inválida");
        }
    }
}