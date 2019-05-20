using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaXadrez partida;
        public Peao(Cor cor, Tabuleiro tabuleiro, PartidaXadrez partida) : base(cor, tabuleiro)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca != null && peca.Cor != Cor;
        }

        private bool Livre(Posicao posicao)
        {
            return Tabuleiro.GetPeca(posicao) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao tempPos = new Posicao(0, 0);
            if (Cor == Cor.branca)
            {
                tempPos.SetPosicao(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(tempPos) && Livre(tempPos) && Livre(new Posicao(tempPos.Linha + 1, tempPos.Coluna)) && QtdMovimentos == 0)
                {
                    matriz[tempPos.Linha, tempPos.Coluna] = true;
                }
                tempPos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(tempPos) && Livre(tempPos))
                {
                    matriz[tempPos.Linha, tempPos.Coluna] = true;
                }
                tempPos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(tempPos) && ExisteInimigo(tempPos))
                {
                    matriz[tempPos.Linha, tempPos.Coluna] = true;
                }
                tempPos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(tempPos) && ExisteInimigo(tempPos))
                {
                    matriz[tempPos.Linha, tempPos.Coluna] = true;
                }
                // #jogadaespecial en passant
                if (Posicao.Linha == 3)
                {
                    tempPos.SetPosicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(tempPos) && ExisteInimigo(tempPos) && Tabuleiro.GetPeca(tempPos) == partida.VulneravelEnPassant)
                    {
                        matriz[tempPos.Linha - 1, tempPos.Coluna] = true;
                    }
                   tempPos.SetPosicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(tempPos) && ExisteInimigo(tempPos) && Tabuleiro.GetPeca(tempPos) == partida.VulneravelEnPassant)
                    {
                        matriz[tempPos.Linha - 1, tempPos.Coluna] = true;
                    }
                }
            }
            else
            {
                tempPos.SetPosicao(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(tempPos) && Livre(tempPos) && Livre(new Posicao(tempPos.Linha - 1, tempPos.Coluna)) && QtdMovimentos == 0)
                {
                    matriz[tempPos.Linha, tempPos.Coluna] = true;
                }
                tempPos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(tempPos) && Livre(tempPos))
                {
                    matriz[tempPos.Linha, tempPos.Coluna] = true;
                }
                tempPos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(tempPos) && ExisteInimigo(tempPos))
                {
                    matriz[tempPos.Linha, tempPos.Coluna] = true;
                }
                tempPos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(tempPos) && ExisteInimigo(tempPos))
                {
                    matriz[tempPos.Linha, tempPos.Coluna] = true;
                }
                // #jogadaespecial en passant
                if (Posicao.Linha == 4)
                {
                    tempPos.SetPosicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(tempPos) && ExisteInimigo(tempPos) && Tabuleiro.GetPeca(tempPos) == partida.VulneravelEnPassant)
                    {
                        matriz[tempPos.Linha + 1, tempPos.Coluna] = true;
                    }
                    tempPos.SetPosicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(tempPos) && ExisteInimigo(tempPos) && Tabuleiro.GetPeca(tempPos) == partida.VulneravelEnPassant)
                    {
                        matriz[tempPos.Linha + 1, tempPos.Coluna] = true;
                    }
                }
            }
            return matriz;
        }
    }
}
