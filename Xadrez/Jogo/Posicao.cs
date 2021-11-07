namespace Jogo
{
    /// <summary>Posiçao generica 2D.</summary>
    class Posicao
    {
        /// <summary>Coluna de um tabuleiro.</summary>
        public int Coluna { get; set; }
        /// <summary>Linha de um tabuleiro.</summary>
        public int Linha { get; set; }

        /// <summary>Construtor da Classe Posição recebendo linha e coluna.</summary>
        /// <param name="linha">linha de uma posição do tabuleiro.</param>
        /// <param name="coluna">coluna de uma posição do tabuleiro.</param>
        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        /// <summary>Metodo para definir valores de uma posiçãono tabuleiro.</summary>
        /// <param name="linha">linha de uma posição do tabuleiro.</param>
        /// <param name="coluna">coluna de uma posição do tabuleiro.</param>
        public void DefinirValores(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        ///  <summary>Sobrecarga do Metodo ToString() para classe Posiçai.</summary>
        ///  <returns>O valor string: linha,coluna.</returns>
        public override string ToString()
        {
            return Linha + "," + Coluna;
        }
    }
}