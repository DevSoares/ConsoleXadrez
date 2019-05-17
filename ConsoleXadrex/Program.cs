using System;
using tabuleiro;
using xadrez;
namespace ConsoleXadrex
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaXadrez partida = new PartidaXadrez();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.Write("\nOrigem:  ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosition();
                        partida.ValidarPosicaoOrigem(origem);

                        Console.Clear();
                        bool[,] movimentosPossiveis = partida.Tabuleiro.GetPeca(origem).MovimentosPossiveis();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro, movimentosPossiveis);

                        Console.Write("\nDestino:  ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosition();
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.ImprimirPartida(partida);
                Console.ReadKey();
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
