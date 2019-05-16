using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public bool Xeque { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> PecasCapturadas;

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            SetTabuleiro();
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutarMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("\nPara de pensar com a bunda!!\nVocê não pode se colocar em Xeque!!");
            }
            Xeque = (EstaEmXeque(Adversario(JogadorAtual))) ? true : false;
            Turno++;
            TrocaJogador();
        }

        private void TrocaJogador()
        {
            if (JogadorAtual == Cor.branca)
            {
                JogadorAtual = Cor.preta;
            }
            else
            {
                JogadorAtual = Cor.branca;
            }
        }

        public void ValidarPosicaoOrigem(Posicao posicao)
        {
            if (Tabuleiro.GetPeca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tabuleiro.GetPeca(posicao).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tabuleiro.GetPeca(posicao).ExisteMovimentoPossivel())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.GetPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public Peca ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.InserirPeca(peca, destino);
            if (pecaCapturada != null)
            {
                PecasCapturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca pecaDaJogada = Tabuleiro.RetirarPeca(destino);
            pecaDaJogada.DecrementarQtdMovimentos();
            if (pecaCapturada !=null)
            {
                Tabuleiro.InserirPeca(pecaCapturada, destino);
                PecasCapturadas.Remove(pecaCapturada);
            }
            Tabuleiro.InserirPeca(pecaDaJogada,origem);
        }

        public HashSet<Peca> GetPecasCapturadas(Cor cor)
        {
            HashSet<Peca> temp = new HashSet<Peca>();
            foreach(Peca peca in PecasCapturadas)
            {
                if(peca.Cor == cor)
                {
                    temp.Add(peca);
                }
            }
            return temp;
        }

        public HashSet<Peca> GetPecasEmJogo(Cor cor)
        {
            HashSet<Peca> temp = new HashSet<Peca>();
            foreach (Peca peca in Pecas)
            {
                if (peca.Cor == cor)
                {
                    temp.Add(peca);
                }
            }
            temp.ExceptWith(GetPecasCapturadas(cor));
            return temp;
        }

        public void ColocarNovaPeca(int linha, int coluna, Peca peca)
        {
            Tabuleiro.InserirPeca(peca, new Posicao(linha, coluna));
            Pecas.Add(peca);
        }

        public Peca GetRei(Cor cor)
        {
            foreach(Peca peca in GetPecasEmJogo(cor))
            {
                if(peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = GetRei(cor);
            if (rei == null)
            {
                throw new TabuleiroException("Deu ruim nessa porra, o Rei não está na partida!");
            }
            foreach(Peca peca in GetPecasEmJogo(Adversario(cor)))
            {
                bool[,] matriz = peca.MovimentosPossiveis();
                if(matriz[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        private Cor Adversario(Cor cor)
        {
            if(cor == Cor.branca)
            {
                return Cor.preta;
            }
            else
            {
                return Cor.branca;
            }
        }

        private void SetTabuleiro()
        {
            ColocarNovaPeca(0, 0, new Torre(Cor.preta, Tabuleiro));
            ColocarNovaPeca(0, 7, new Torre(Cor.preta, Tabuleiro));
            ColocarNovaPeca(0, 4, new Rei(Cor.preta, Tabuleiro));

            ColocarNovaPeca(7, 0, new Torre(Cor.branca, Tabuleiro));
            ColocarNovaPeca(7, 7, new Torre(Cor.branca, Tabuleiro));
            ColocarNovaPeca(7, 4, new Rei(Cor.branca, Tabuleiro));

        }
    }
}
