using System;
using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[8, 8];
            Posicao tempPosicao = new Posicao(Posicao.Linha, Posicao.Coluna);
            // N
            tempPosicao.SetPosicao(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }
            // NE
            tempPosicao.SetPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }
            // E
            tempPosicao.SetPosicao(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }
            // SE
            tempPosicao.SetPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }
            // S
            tempPosicao.SetPosicao(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }
            // SW
            tempPosicao.SetPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }
            // W
            tempPosicao.SetPosicao(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }
            // NW
            tempPosicao.SetPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(tempPosicao) && PodeMover(tempPosicao))
            {
                matriz[tempPosicao.Linha, tempPosicao.Coluna] = true;
            }
            return matriz;
        }
    }
}
