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