using tabuleiro;
namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);
            posicao.SetPosicao(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(Posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.SetPosicao(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(Posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.SetPosicao(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(Posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.SetPosicao(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(Posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.SetPosicao(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(Posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.SetPosicao(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(Posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.SetPosicao(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(Posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }
            posicao.SetPosicao(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(posicao) && PodeMover(Posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }
            return matriz;
        }
    }
}
