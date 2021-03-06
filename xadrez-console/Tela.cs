﻿using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Tela {
        public static void imprimirPartida(PartidaDeXadrex partida) {
            ConsoleColor aux2 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***** XADREZ *****");
            Console.ForegroundColor = aux2;
            Console.WriteLine();
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine("Turno: " + partida.turno);
            if(!partida.terminada) {
                if(partida.jogadorAtual == Cor.Branca) {
                    Console.Write("Aguardando Jogada: " + partida.jogadorAtual);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.Write("Aguardando Jogada: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(partida.jogadorAtual);
                    Console.ForegroundColor = aux;
                }
                if(partida.xeque) {
                    Console.WriteLine();
                    Console.WriteLine("XEQUE!");
                }
                Console.WriteLine();
            }
            else {
                Console.WriteLine("XEQUEMATE!");
                if(partida.jogadorAtual == Cor.Branca) {
                    Console.Write("Vencedor: " + partida.jogadorAtual);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.Write("Vencedor: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(partida.jogadorAtual);
                    Console.ForegroundColor = aux;
                }
                Console.WriteLine();
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrex partida) {
            Console.WriteLine("Peças Capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            foreach(Peca x in conjunto) {
                Console.Write(x + " ");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        public static void imprimirTabuleiro(Tabuleiro tab) {

            for (int i=0; i<tab.linhas; i++) {
                ConsoleColor aux1 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux1;
                for (int j=0; j<tab.colunas; j++) {
                    imprimirPeca(tab.peca(i, j));
                    }
                Console.WriteLine();
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = aux;
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool [,] posicoesPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for(int i = 0;i < tab.linhas;i++) {
                ConsoleColor aux1 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = aux1;
                for(int j = 0;j < tab.colunas;j++) {
                    if(posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = aux;
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca) {
            if(peca == null)
                Console.Write("- ");

            else {
                if(peca.cor == Cor.Branca) {
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
