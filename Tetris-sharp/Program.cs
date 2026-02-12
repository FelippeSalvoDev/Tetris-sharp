using System;
using System.IO;
using System.Text;

class JogoTetris
{
    private int linhas = 20;
    private int colunas = 10;

    private int[,] tabuleiro;
    private int[,] pecaAtual;

    private int posicaoX;
    private int posicaoY;

    private int pontos = 0;
    private string nomeJogador;

    public void Comecar()
    {
        tabuleiro = new int[linhas, colunas];

        Console.WriteLine("Digite seu nome: ");
        nomeJogador = Console.ReadLine();

        while (true)
        {
            pecaAtual = gerarPeca();
            posicaoX = 0;
            posicaoY = colunas / 2 - 1; //Sempre gera a peça no meio 

            if (ColidiuPeca(pecaAtual, posicaoX, posicaoY))
            {
                Console.Clear();
                Console.WriteLine("FIM DE JOGO");
                break;
            }

            bool caiu = false;

            while (!caiu)
            {
                Console.Clear();

                Console.WriteLine("A = Esquerda | D = Direita | S = Descer");

                var tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.A:
                        if (!ColidiuPeca(pecaAtual, posicaoX, posicaoX))
                            posicaoY--; //Move para esquerda
                        break;
                    case ConsoleKey.D:
                        if (!ColidiuPeca(pecaAtual, posicaoX, posicaoX))
                            posicaoY++; //Move para direita
                        break;
                    case ConsoleKey.S:
                        if (!ColidiuPeca(pecaAtual, posicaoX, posicaoX))
                            posicaoX++; //Move para baixo
                        else
                        {
                            ColocarPeca();
                            caiu = true;
                        }
                        break;
                }
            }
        }
    }

    int[,] gerarPeca()
    { 
        Random rnd = new Random();
        int tipo = rnd.Next(0, 3);

        switch (tipo)
        {
            case 0:
                return new int[,]{{1,
                                   1,
                                   1, }};
            case 1:
                return new int[,]{{1,0},
                                  {1,0},
                                  {1,1}};
            case 2:
                return new int[,]{{1,1,1},
                                  {0,1,0}};
            default:
                return null;
        }
    }

    bool ControlePecaAatual(int x, int y)
    {
        for (int i = 0; i < pecaAtual.GetLength(0); i++)
        {
            for (int j = 0; j < pecaAtual.GetLength(0); j++)
            {
                if (pecaAtual[i, j] == 1)
                {
                    int px = posicaoX + i;
                    int py = posicaoY + j;
                    if (px == x && py == y)
                        return true;
                }
            }
        }
    }

    bool ColidiuPeca(int[,] peca, int x, int y)
    {
        for (int i = 0; i < peca.GetLength(0); i++)
        {
            for (int j = 0; j < peca.GetLength(1); j++)
            {
                if (peca[i, j] == 1)
                {
                    int px = x + 1;
                    int py = y + 1;

                    if (px < 0 || px >= linhas || py < 0 || py >= colunas) //Garante que a peça não escape do tabuleiro
                        return true;
                    if (tabuleiro[px, py] == 1)
                        return true;
                }
            }
        }
        return false;
    }

    void ColocarPeca()
    {
        for (int i = 0; i < pecaAtual.GetLength(0); i++)
        {
            for (int j = 0; j < pecaAtual.GetLength(1); j++)
            {
                if ((pecaAtual[i, j] == 1))
                {
                    int px = posicaoX + i;
                    int py = posicaoY + j;
                    if (px >= 0 && px < linhas && py >= 0 && py < colunas) //Garante que a peça não escape do tabuleiro
                        tabuleiro[px, py] = 1; //Coloca a peça
                }
            }
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    { 
        JogoTetris jogo = new JogoTetris();
        jogo.Comecar();
    }
}