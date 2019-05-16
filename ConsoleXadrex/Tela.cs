using System;
using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace ConsoleXadrex
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.GetPeca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] matriz)
        {

            ConsoleColor originalBg = Console.BackgroundColor;
            ConsoleColor alternativeBg = ConsoleColor.Cyan;
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (matriz[i,j])
                    {
                        Console.BackgroundColor = alternativeBg;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBg;
                    }
                    ImprimirPeca(tab.GetPeca(i, j));
                    Console.BackgroundColor = originalBg;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");            
        }

        public static void ImprimirPartida(PartidaXadrez partida)
        {            
            ImprimirTabuleiro(partida.Tabuleiro);
            ImprimirPecasCapturadas(partida);
            Console.WriteLine("\n Turno: " + partida.Turno);
            Console.WriteLine(" Aguardando... " + partida.JogadorAtual);
            if (partida.Xeque)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nXEQUE CARAIO!!");
                Console.ForegroundColor = aux;
            }
        }

        public static void ImprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("\nPeças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.GetPecasCapturadas(Cor.branca));
            Console.Write("\nPretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            ImprimirConjunto(partida.GetPecasCapturadas(Cor.preta));
            Console.ForegroundColor = aux;

        }

        public static void ImprimirConjunto(HashSet<Peca> pecas)
        {
            Console.Write("[");
            foreach(Peca x in pecas)
            {
                Console.Write(x.ToString()+" ");
            }
            Console.Write("]");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[1];
            int linha = int.Parse(s[0].ToString());
            return new PosicaoXadrez(linha, coluna);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
