using tabuleiro;
namespace xadrez
{
    class Queen : Peca
    {
        public Queen(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao tempPos = new Posicao(0, 0);
            // W
            tempPos.SetPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(tempPos) && PodeMover(tempPos))
            {
                matriz[tempPos.Linha, tempPos.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPos) != null && Tabuleiro.GetPeca(tempPos).Cor != Cor)
                {
                    break;
                }
                tempPos.SetPosicao(tempPos.Linha, tempPos.Coluna - 1);
            }
            // N
            tempPos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(tempPos) && PodeMover(tempPos))
            {
                matriz[tempPos.Linha, tempPos.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPos) != null && Tabuleiro.GetPeca(tempPos).Cor != Cor)
                {
                    break;
                }
                tempPos.SetPosicao(tempPos.Linha - 1, tempPos.Coluna);
            }
            // E
            tempPos.SetPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(tempPos) && PodeMover(tempPos))
            {
                matriz[tempPos.Linha, tempPos.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPos) != null && Tabuleiro.GetPeca(tempPos).Cor != Cor)
                {
                    break;
                }
                tempPos.SetPosicao(tempPos.Linha, tempPos.Coluna + 1);
            }
            // S
            tempPos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(tempPos) && PodeMover(tempPos))
            {
                matriz[tempPos.Linha, tempPos.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPos) != null && Tabuleiro.GetPeca(tempPos).Cor != Cor)
                {
                    break;
                }
                tempPos.SetPosicao(tempPos.Linha + 1, tempPos.Coluna);
            }
            // NW
            tempPos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(tempPos) && PodeMover(tempPos))
            {
                matriz[tempPos.Linha, tempPos.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPos) != null && Tabuleiro.GetPeca(tempPos).Cor != Cor)
                {
                    break;
                }
                tempPos.SetPosicao(tempPos.Linha - 1, tempPos.Coluna - 1);
            }
            // NE
            tempPos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(tempPos) && PodeMover(tempPos))
            {
                matriz[tempPos.Linha, tempPos.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPos) != null && Tabuleiro.GetPeca(tempPos).Cor != Cor)
                {
                    break;
                }
                tempPos.SetPosicao(tempPos.Linha - 1, tempPos.Coluna + 1);
            }
            // SE
            tempPos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(tempPos) && PodeMover(tempPos))
            {
                matriz[tempPos.Linha, tempPos.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPos) != null && Tabuleiro.GetPeca(tempPos).Cor != Cor)
                {
                    break;
                }
                tempPos.SetPosicao(tempPos.Linha + 1, tempPos.Coluna + 1);
            }
            // SW
            tempPos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(tempPos) && PodeMover(tempPos))
            {
                matriz[tempPos.Linha, tempPos.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPos) != null && Tabuleiro.GetPeca(tempPos).Cor != Cor)
                {
                    break;
                }
                tempPos.SetPosicao(tempPos.Linha + 1, tempPos.Coluna - 1);
            }
            return matriz;
        }
    }
}
