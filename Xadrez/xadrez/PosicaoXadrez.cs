using Jogo;

namespace Xadrez
{
    /// <summary>Posição de Xadrez.</summary>
    class PosicaoXadrez
    {
        /// <summary>Coluna de um tabuleiro de Xadrez.</summary>
        public char Coluna { get; set; }
        /// <summary>Linha de um tabuleiro de Xadrez.</summary>
        public int Linha { get; set; }

        /// <summary>Construtor com parametros de coluna e linha.</summary>
        /// <param name="coluna">Coluna de um tabuleiro de Xadrez.</param>
        /// <param name="linha">Coluna de um tabuleiro de Xadrez.</param>
        public PosicaoXadrez(char coluna, int linha)
        {
            Linha = linha;
            Coluna = coluna;
        }
        /// <summary>Converte o valor de uma linha e coluna para sua representação em posição do Xadrez.</summary>
        public Posicao toPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        /// <summary>Sobrecarga do Metodo ToString() para classe PosicaoXadrez.</summary>
        /// <returns>O valor string em da coluna e linha.</returns>
        public override string ToString()
        {
            // return ""coluna+linha;
            return Coluna + Linha.ToString();
        }
    }
}