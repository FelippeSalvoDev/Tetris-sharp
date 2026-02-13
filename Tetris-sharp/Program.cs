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
                Console.WriteLine($"Pontuação final: {pontos}");
                ContarPontos();
                break;
            }

            bool caiu = false;

            while (!caiu)
            {
                Console.Clear();
                CriarTabuleiro();
                Console.WriteLine($"\nPontuação: {pontos}");
                Console.WriteLine("A = Esquerda | D = Direita | S = Descer | R = Girar horário | E = Girar anti-horário");

                var tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.A:
                        if (!ColidiuPeca(pecaAtual, posicaoX, posicaoY - 1))
                            posicaoY--; //Move para esquerda
                        break;
                    case ConsoleKey.D:
                        if (!ColidiuPeca(pecaAtual, posicaoX, posicaoY + 1))
                            posicaoY++; //Move para direita
                        break;
                    case ConsoleKey.S:
                        if (!ColidiuPeca(pecaAtual, posicaoX + 1, posicaoY))
                            posicaoX++; //Move para baixo
                        else
                        {
                            ColocarPeca();
                            VerificarLinhas();
                            caiu = true;
                        }
                        break;
                    case ConsoleKey.R:
                        var horario = RotacionarPecaHorario(pecaAtual);
                        if (!ColidiuPeca(horario, posicaoX, posicaoY))
                            pecaAtual = horario;
                        break;
                    case ConsoleKey.E:
                        var antihorario = RotacionarPecaAntihorario(pecaAtual);
                        if (!ColidiuPeca(antihorario, posicaoX, posicaoY))
                            pecaAtual = antihorario;
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
                return new int[,] { {1,
                                     1,
                                     1} };
            case 1:
                return new int[,]  {{ 1,0 },
                                    { 1,0 },
                                    { 1,1 } };
            case 2:
                return new int[,] { {1,1,1},
                                    {0,1,0} };
            default:
                return null;
        }
    }

    int[,] RotacionarPecaHorario(int[,] peca)
    { 
        int linhas = peca.GetLength(0);
        int colunas = peca.GetLength(1);
        int[,] nova = new int[colunas, linhas];

        for (int i = 0; i < linhas; i++)
            for (int j = 0; j < colunas; j++)
                nova[j, linhas - i - 1] = peca[i, j];
        
        return nova;
    }

    int[,] RotacionarPecaAntihorario(int[,] peca)
    {
        int linha = peca.GetLength(0);
        int coluna = peca.GetLength(1);
        int[,] nova = new int[coluna, linha];

        for (int i = 0; i < linha; i++)
            for (int j = 0; j < coluna; j++)
                nova[coluna - j - 1, i] = peca[i, j];
       
        return nova;
    }

    bool ControlePecaAtual(int x, int y)
    {
        for (int i = 0; i < pecaAtual.GetLength(0); i++)
        {
            for (int j = 0; j < pecaAtual.GetLength(1); j++)
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
        return false;
    }

    bool ColidiuPeca(int[,] peca, int x, int y)
    {
        for (int i = 0; i < peca.GetLength(0); i++)
        {
            for (int j = 0; j < peca.GetLength(1); j++)
            {
                if (peca[i, j] == 1)
                {
                    int px = x + i;
                    int py = y + j;

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
                if (pecaAtual[i, j] == 1)
                {
                    int px = posicaoX + i;
                    int py = posicaoY + j;
                    if (px >= 0 && px < linhas && py >= 0 && py < colunas) //Garante que a peça não escape do tabuleiro
                        tabuleiro[px, py] = 1; //Coloca a peça
                }
            }
        }
    }

    void VerificarLinhas()
    {
        for (int i = linhas - 1; i >= 0; i--)
        {
            bool completa = true;
            for (int j = 0; j < colunas; j++)
            {
                if (tabuleiro[i, j] == 0)
                {
                    completa = false;
                    break;
                }
            }
            if (completa)
            {
                for (int k = i; k > 0; k--)
                    for (int j = 0; j < colunas; j++)
                        tabuleiro[k, j] = tabuleiro[k - 1, j];

                for (int j = 0; j < colunas; j++)
                    tabuleiro[0, j] = 0;

                pontos += 100;
                i++;
            }
        }
    }

    void CriarTabuleiro()
    {
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                if (tabuleiro[i, j] == 1 || ControlePecaAtual(i, j))
                    Console.Write("[]"); //Imprime partes da peça
                else
                    Console.Write(" ."); //Imprime o tabuleiro
            }
            Console.WriteLine();
        }
    }
    void ContarPontos()
    {
        try
        {
            StreamWriter arq = new StreamWriter("scores.txt", true, Encoding.UTF8);
            arq.WriteLine(nomeJogador + ";" + pontos);
            arq.Close();

            Console.WriteLine("Pontuação salva com sucesso.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
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