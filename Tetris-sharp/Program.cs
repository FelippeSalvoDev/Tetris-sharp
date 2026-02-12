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
}

internal class Program
{
    private static void Main(string[] args)
    { 
        JogoTetris jogo = new JogoTetris();
        jogo.Comecar();
    }
}