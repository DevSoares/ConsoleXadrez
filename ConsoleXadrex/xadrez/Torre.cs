using System;
using tabuleiro;
namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao tempPosicao = new Posicao(Posicao.Linha, Posicao.Coluna);

            // N
            tempPosicao.SetPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPosicao) != null && Tabuleiro.GetPeca(tempPosicao).Cor != Cor)
                {
                    break;
                }
                tempPosicao.Linha--;
            }

            // S
            tempPosicao.SetPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPosicao) != null && Tabuleiro.GetPeca(tempPosicao).Cor != Cor)
                {
                    break;
                }
                tempPosicao.Linha++;
            }

            //E
            tempPosicao.SetPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPosicao) != null && Tabuleiro.GetPeca(tempPosicao).Cor != Cor)
                {
                    break;
                }
                tempPosicao.Coluna++;
            }

            // W
            tempPosicao.SetPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
                if (Tabuleiro.GetPeca(tempPosicao) != null && Tabuleiro.GetPeca(tempPosicao).Cor != Cor)
                {
                    break;
                }
                tempPosicao.Coluna--;
            }
            return matriz;
        }
    }
}
