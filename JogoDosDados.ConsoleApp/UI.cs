namespace jogoDosDados.ConsoleApp;

public static class UI
{
    public static void WelcomeMessage()
    {
        Console.WriteLine("\nBoas vindas ao jogo de corrida dos dados!\n");
        Console.WriteLine("Aperte ENTER para iniciar...");
        Console.ReadKey();
    }

    public static void Header(string currentPlayer, int p1Pos, int cpu, int finishLine)
    {
        Console.Clear();
        Console.WriteLine($"\nTurno do {currentPlayer}\n");
        Console.WriteLine($"Você está na posição {p1Pos} de {finishLine}");
        Console.WriteLine($"Computador está na posição {cpu} de {finishLine}\n");
    }

    public static bool Retry()
    {
        Console.WriteLine("Deseja continuar? (s/n)");
        string? retry = Console.ReadLine()?.ToUpper();
        return retry == "S";
    }
}