using tabuleiro;
namespace xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(int linha, char coluna)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ToPosition()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return Coluna + Linha.ToString();
        }
    }
}
