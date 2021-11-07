using Jogo;
using System.Collections.Generic;

namespace Xadrez
{
    /// <summary>Possiveis Movimentos da peça Rei.</summary>
    class PartidaDeXadrez
    {
        /// <summary>Tabuleiro de Xadrez.</summary>
        public Tabuleiro Tab { get; private set; }
        /// <summary>Turno atual de Xadrez.</summary>
        public int Turno { get; private set; }
        /// <summary>Cor da vez do jogador atual.</summary>
        public Cor JogadorAtual { get; private set; }
        /// <summary>Valor se a partida de Xadrez está terminada.</summary>
        public bool Terminada { get; private set; }
        /// <summary>Peças de Xadrez.</summary>
        private HashSet<Peca> Pecas;
        /// <summary>Peças capturadas no Xadrez.</summary>
        private HashSet<Peca> Capturadas;
        /// <summary>Checa se a partida está em xeque</summary>
        public bool Xeque { get; private set; }
        /// <summary>Define se o peão está em vuneravel ao En Passant</summary>
        public Peca VulneravelEnPassant { get; private set; }

        /// <summary>Construtor da partida de Xadrez.</summary>
        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            VulneravelEnPassant = null;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        /// <summary>Executa um movimento na partida de Xadrez.</summary>
        /// <param name="origem">Posição inicial de onde a peça moverá.</param>
        /// <param name="destino">Posição para onde a peça irá.</param>
        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tab.RetirarPeca(origem);
            peca.IncrementarQteMovimento();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(peca, destino);
            if (pecaCapturada != null)
                Capturadas.Add(pecaCapturada);
            //Roque Pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemTablueiro = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTabuleiro = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca pecaTabuleiro = Tab.RetirarPeca(origemTablueiro);
                pecaTabuleiro.IncrementarQteMovimento();
                Tab.ColocarPeca(pecaTabuleiro, destinoTabuleiro);
            }
            //Roque Grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemTablueiro = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTabuleiro = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca pecaTabuleiro = Tab.RetirarPeca(origemTablueiro);
                pecaTabuleiro.IncrementarQteMovimento();
                Tab.ColocarPeca(pecaTabuleiro, destinoTabuleiro);
            }
            //En Passant
            if (peca is Peao)
            {
                if (origem.Coluna != destino.Coluna && pecaCapturada == null)
                {
                    Posicao pecaPosicao;
                    if (peca.CorPeca == Cor.Branca)
                        pecaPosicao = new Posicao(destino.Linha + 1, destino.Coluna);
                    else
                        pecaPosicao = new Posicao(destino.Linha - 1, destino.Coluna);
                    pecaCapturada = Tab.RetirarPeca(pecaPosicao);
                    Capturadas.Add(pecaCapturada);
                }
            }
            return pecaCapturada;
        }

        /// <summary>Desfaz um movimento feito.</summary>
        /// <param name="origem">Posiçao no qual a peça rertonará.</param>
        /// <param name="destino">Posição desfeita.</param>
        /// <param name="pecaCapturada">Peça a ser recolocada no jogo.</param>
        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = Tab.RetirarPeca(destino);
            peca.DecrementarQteMovimentos();
            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(peca, origem);
            //Roque Pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tab.RetirarPeca(destinoT);
                T.DecrementarQteMovimentos();
                Tab.ColocarPeca(T, origemT);
            }
            //Roque Grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tab.RetirarPeca(destinoT);
                T.DecrementarQteMovimentos();
                Tab.ColocarPeca(T, origemT);
            }
            //En Passant
            if (peca is Peao)
            {
                if (origem.Coluna != destino.Coluna && pecaCapturada == VulneravelEnPassant)
                {
                    Peca peao = Tab.RetirarPeca(destino);
                    Posicao posP;
                    if (peca.CorPeca == Cor.Branca)
                        posP = new Posicao(3, destino.Coluna);
                    else
                        posP = new Posicao(4, destino.Coluna);
                    Tab.ColocarPeca(peao, posP);
                }
            }
        }

        /// <summary>Conclui uma jogada no Xadrez.</summary>
        /// <param name="origem">Posição inicial de onde a peça se moveu.</param>
        /// <param name="destino">Posição para onde a peça moveu.</param>
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque");
            }
            Peca peca = Tab.Peca(destino);
            //Joga Especial Promoção
            if (peca is Peao)
            {
                if ((peca.CorPeca == Cor.Branca && destino.Linha == 0) || (peca.CorPeca == Cor.Preta && destino.Linha == 7))
                {
                    peca = Tab.RetirarPeca(destino);
                    Pecas.Remove(peca);
                    Peca dama = new Dama(Tab, peca.CorPeca);
                    Tab.ColocarPeca(dama, destino) ;
                    Pecas.Add(dama);
                }
            }
            if (EstaEmXeque(Adversaria(JogadorAtual)))
                Xeque = true;
            else
                Xeque = false;
            if (TesteXequemate(Adversaria(JogadorAtual)))
                Terminada = true;
            else
            {
                Turno++;
                MudarJogador();
            }
            //Jogada Especial En Passant
            if (peca is Peao && (destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2))
                VulneravelEnPassant = peca;
            else
                VulneravelEnPassant = null;
        }

        /// <summary>Checa se a posição inicial é valida.</summary>/// <summary>Checa se a posição inicial é valida.</summary>
        /// <param name="pos">Posição inicial da peça desejada para mover.</param>
        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
                throw new TabuleiroException("Não Existe peça na posição de origem escolhida");
            if (JogadorAtual != Tab.Peca(pos).CorPeca)
                throw new TabuleiroException("Peça escolhida não é do jogador atual");
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida");
        }

        /// <summary>Checa se a posição de destino é valida.</summary>
        /// <param name="origem">Posição inicial de onde a peça se moveu.</param>
        /// <param name="destino">Posição para onde a peça quer se mover.</param>
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PossivelMovimento(destino))
                throw new TabuleiroException("Posição de destino Inválida");
        }

        /// <summary>Muda vez do jogador.</summary>
        private void MudarJogador()
        {
            if (JogadorAtual == Cor.Branca)
                JogadorAtual = Cor.Preta;
            else
                JogadorAtual = Cor.Branca;
        }

        /// <summary>Retorna as peças capturadas de um jogador.</summary>
        /// <returns>Peças capturadas do jogador em HashSet.</returns>
        public HashSet<Peca> PecasCapturadas(Cor CorPeca)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.CorPeca.Equals(CorPeca))
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        /// <summary>Retorna as peças em jogo de um jogador.</summary>
        /// <returns>Peças em jogo do jogador em HashSet.</returns>
        public HashSet<Peca> PecasEmJogo(Cor CorPeca)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca item in Pecas)
            {
                if (item.CorPeca == CorPeca)
                    aux.Add(item);
            }
            aux.ExceptWith(PecasCapturadas(CorPeca));
            return aux;
        }

        /// <summary>Determina a CorPeca do adversario.</summary>
        /// <param name="CorPeca">Cor do jogador.</param> 
        /// <returns>Enumeraçao Cor como Preto ou Branco.</returns>
        private Cor Adversaria(Cor CorPeca)
        {
            if (CorPeca == Cor.Branca)
                return Cor.Preta;
            else
                return Cor.Branca;
        }

        /// <summary>Retorna o rei de um jogador.</summary>
        /// <param name="CorPeca">Cor do jogador para descorir o Rei</param>
        /// <returns>O Rei, caso o rei não exista retorna null</returns>
        private Peca PecaRei(Cor CorPeca)
        {
            foreach (Peca item in PecasEmJogo(CorPeca))
            {
                if (item is Rei)
                    return item;
            }
            return null;
        }

        /// <summary>Checa se o rei do jogador está em xeque.</summary>
        /// <param name="CorPeca">Cor do jogador.</param>
        /// <returns>Se o jogador está em xeque retorna True, se não False.</returns>
        public bool EstaEmXeque(Cor CorPeca)
        {
            Peca rei = PecaRei(CorPeca);
            if (rei == null)
                throw new TabuleiroException("Não existe Rei da Cor " + CorPeca + " no Tabuleiro");
            foreach (Peca item in PecasEmJogo(Adversaria(CorPeca)))
            {
                bool[,] mat = item.MovimentosPossiveis();
                if (mat[rei.PosicaoPeca.Linha, rei.PosicaoPeca.Coluna])
                    return true;
            }
            return false;
        }

        /// <summary>Testa se o jogador sofreu um Xequemate.</summary>
        /// <param name="CorPeca">Cor do jogador para ser testado.</param>
        /// <returns>False se o jogador não sofreu um Xequemate, True se sofreu.</returns>
        public bool TesteXequemate(Cor CorPeca)
        {
            if (!EstaEmXeque(CorPeca))
                return false;
            foreach (Peca item in PecasEmJogo(CorPeca))
            {
                bool[,] mat = item.MovimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = item.PosicaoPeca;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(CorPeca);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                                return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>Coloca as peças no em jogo de Xadrez.</summary>
        /// <param name="coluna">Coluna onde a peça sera colocada.</param>
        /// <param name="linha">Linha onde a peça sera colocada.</param>
        /// <param name="peca">Peça que será colocada.</param>
        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            Pecas.Add(peca);
        }

        /// <summary>Instancia todas as peças em um jogo de Xadrez.</summary>
        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tab, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('b', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(Tab, Cor.Branca, this));

            ColocarNovaPeca('a', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(Tab, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('g', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('h', 7, new Peao(Tab, Cor.Preta, this));
        }
    }
}