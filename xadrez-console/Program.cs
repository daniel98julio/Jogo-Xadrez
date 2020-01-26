using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                PartidaDeXadrex partida = new PartidaDeXadrex();

                while(!partida.terminada) {
                    try {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);

                        if(partida.jogadorAtual == Cor.Branca) {
                            Console.WriteLine("Aguardando Jogada: " + partida.jogadorAtual);
                        }
                        else {
                            ConsoleColor aux = Console.ForegroundColor;
                            Console.Write("Aguardando Jogada: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(partida.jogadorAtual);
                            Console.ForegroundColor = aux;
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch(TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

        }
    }
}
