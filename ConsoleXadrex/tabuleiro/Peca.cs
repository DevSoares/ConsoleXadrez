namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca( Cor cor, Tabuleiro tabuleiro)
        {            
            Cor = cor;
            Tabuleiro = tabuleiro;
        }

        public void IncrementarQtdMovimentos()
        {
            QtdMovimentos++;
        }

        public void DecrementarQtdMovimentos()
        {
            QtdMovimentos--;
        }

        public bool PodeMover(Posicao pos)
        {
            Peca peca = Tabuleiro.GetPeca(pos);
            return peca == null || peca.Cor != Cor;
        }

        public bool ExisteMovimentoPossivel()
        {
            bool[,] tempMatriz = MovimentosPossiveis();
            for(int i=0; i<Tabuleiro.Linhas; i++)
            {
                for(int j=0; j<Tabuleiro.Colunas; j++)
                {
                    if (tempMatriz[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
