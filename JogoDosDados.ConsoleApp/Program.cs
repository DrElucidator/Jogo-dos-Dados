using System.Security.Cryptography;

namespace jogoDosDados.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        WelcomeMessage();

        const int FinishLine = 30;
        const int BonusRoll = 3;
        const int Penalty = 2;

        while (true)
        {
            PlayRound(FinishLine, BonusRoll, Penalty);

            if (!Retry())
                break;
        }
    }
    static void WelcomeMessage()
    {
        System.Console.WriteLine("\nBoas vindas ao jogo de corrida dos dados!\n");
        System.Console.WriteLine("Aperte ENTER para iniciar...");
        System.Console.ReadKey();
        return;
    }
    static void PlayRound(int FinishLine, int BonusRoll, int Penalty)
    {
        int P1Pos = 0; int CPU = 0;
        bool Round = true;
        int CurrentPlayerTurn = 0;
        string[] Player = { "Jogador", "Computador" };

        while (Round)
        {
            string CurrentPlayer = Player[CurrentPlayerTurn];

            #region Player 1
            if (CurrentPlayerTurn == 0)
            {
                do
                {
                    Header(CurrentPlayer, P1Pos, CPU, FinishLine);
                    System.Console.WriteLine("\nPressione ENTER para jogar o dado...");
                    System.Console.ReadKey();
                    P1Pos = RollDice("Jogador", P1Pos, BonusRoll, Penalty, FinishLine);

                    System.Console.WriteLine("Pressione ENTER para continuar...");
                    System.Console.ReadKey();
                    if (P1Pos < FinishLine)
                    {
                        System.Console.WriteLine($"Você está na posição {P1Pos} de {FinishLine}");
                    }
                    if (P1Pos >= FinishLine)
                    {
                        System.Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                        Round = false;
                    }
                    break;
                } while (true);
            }
            #endregion

            #region CPU
            else
            {
                do
                {
                    Header(CurrentPlayer, P1Pos, CPU, FinishLine);
                    System.Console.WriteLine("\nPressione ENTER para continuar...");
                    System.Console.ReadKey();
                    CPU = RollDice("Computador", CPU, BonusRoll, Penalty, FinishLine);

                    if (CPU < FinishLine)
                    {
                        System.Console.WriteLine("Pressione ENTER para continuar...");
                        System.Console.ReadKey();
                    }
                    if (CPU >= FinishLine)
                    {
                        System.Console.WriteLine("Que pena o computador alcançou a linha de chegada primeiro!");
                        Round = false;
                        System.Console.WriteLine("Pressione ENTER para continuar...");
                        System.Console.ReadKey();
                    }
                    break;
                } while (true);
            }
            #endregion

            CurrentPlayerTurn = (CurrentPlayerTurn + 1) % 2;
        }
    }
    static void Header(String CurrentPlayer, int P1Pos, int CPU, int FinishLine)
    {
        Console.Clear();
        System.Console.WriteLine($"\nTurno do {CurrentPlayer}\n");
        System.Console.WriteLine($"Você está na posição {P1Pos} de {FinishLine}");
        System.Console.WriteLine($"Computador está na posição {CPU} de {FinishLine}\n");
    }
    static int RollDice(string player, int position, int bonus, int penalty, int finishLine)
    {
        int dice = RandomNumberGenerator.GetInt32(1, 7);
        Console.WriteLine($"{player} rolou {dice}");

        position += dice;

        if (position == 5 || position == 10 || position == 15 || position == 20)
        {
            Console.WriteLine($"Bonus de avanço: {bonus}");
            position += bonus;
        }
        else if (position == 7 || position == 13 || position == 20)
        {
            Console.WriteLine($"Penalidade! {player} volta {penalty} casas");
            position -= penalty;
        }

        if (dice == 6)
        {
            Console.WriteLine($"{player} ganhou uma jogada extra!");
            System.Console.WriteLine("Pressione ENTER para que o dado seja rolado novamente...");
            System.Console.ReadKey();
            return RollDice(player, position, bonus, penalty, finishLine);
        }

        Console.WriteLine($"{player} está na posição {position} de {finishLine}");
        return position;
    }
    static bool Retry()
    {
        System.Console.WriteLine("Deseja continuar? (s/n)");
        string? Retry = Console.ReadLine()?.ToUpper();
        if (Retry != "S")
            return false;
        return true;
    }
}