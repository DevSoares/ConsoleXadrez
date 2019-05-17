using System;
using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {
        private PartidaXadrez partida { get; set; }
        public Rei(Cor cor, Tabuleiro tab, PartidaXadrez partida) : base(cor, tab)
        {
            this.partida = partida;
        }

        private bool TestarRoque(Posicao pos)
        {
            Peca peca = Tabuleiro.GetPeca(pos);
            return peca != null && peca is Torre && peca.Cor == Cor && peca.QtdMovimentos == 0;
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
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

            // #JogadaEspecial Roque
            if (QtdMovimentos == 0 && !partida.Xeque)
            {
                // #JogadaEspecial Roque Pequeno
                Posicao posTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TestarRoque(posTorre1))
                {
                    Posicao tempPos1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao tempPos2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if (Tabuleiro.GetPeca(tempPos1) == null && Tabuleiro.GetPeca(tempPos2) == null)
                    {
                        matriz[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }
                // #JogadaEspecial Roque Grande
                Posicao posTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TestarRoque(posTorre2))
                {
                    Posicao tempPos1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao tempPos2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao tempPos3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiro.GetPeca(tempPos1) == null && Tabuleiro.GetPeca(tempPos2) == null && Tabuleiro.GetPeca(tempPos3) == null)
                    {
                        matriz[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }                
            }
            return matriz;
        }
    }
}
