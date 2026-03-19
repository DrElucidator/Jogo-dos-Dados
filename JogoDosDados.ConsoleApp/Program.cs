using System.Security.Cryptography;

namespace jogoDosDados.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Jogo de corrida dos dados");
        System.Console.WriteLine();
        System.Console.WriteLine("Aperte ENTER para continuar...");
        System.Console.ReadKey();

        const int FinishLine = 30;
        const int BonusRoll = 3;
        const int Penalty = 2;

        while (true)
        {
            int P1Pos = 0; int CPU = 0;
            bool Round = true;
            while (Round)
            {
                Console.Clear();
                System.Console.WriteLine();
                System.Console.WriteLine("Turno do Jogador");
                System.Console.WriteLine();
                System.Console.WriteLine($"Você está na posição {P1Pos} de {FinishLine}");
                System.Console.WriteLine($"Computador está na posição {CPU} de {FinishLine}");
                System.Console.WriteLine();
                System.Console.WriteLine("Pressione ENTER para jogar o dado...");
                System.Console.ReadKey();
                int Dice = RandomNumberGenerator.GetInt32(1, 7);
                System.Console.WriteLine();
                System.Console.WriteLine($"O dado rolou {Dice}");
                System.Console.WriteLine();

                P1Pos += Dice;
                if (P1Pos == 5 || P1Pos == 10 || P1Pos == 15 || P1Pos == 20)
                {
                    System.Console.WriteLine($"\nBonus de avanço: {BonusRoll}");
                    P1Pos += BonusRoll;
                }
                else if (P1Pos == 7 || P1Pos == 13 || P1Pos == 20)
                {
                    System.Console.WriteLine($"\nPenalidade! Volte {Penalty} casas");
                    P1Pos -= Penalty;
                }

                if (P1Pos < FinishLine)
                {
                    System.Console.WriteLine($"Você está na posição {P1Pos} de {FinishLine}");
                }
                if (P1Pos >= FinishLine)
                {
                    System.Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                    Round = false;
                }
                System.Console.WriteLine("Pressione ENTER para continuar...");
                System.Console.ReadKey();
               
                System.Console.WriteLine();
                System.Console.WriteLine("Turno do Computador");
                System.Console.WriteLine();
                System.Console.WriteLine($"Computador está na posição {CPU} de {FinishLine}");
                System.Console.WriteLine();
                System.Console.WriteLine("Pressione ENTER para continuar...");
                System.Console.ReadKey();
                int Dice2 = RandomNumberGenerator.GetInt32(1, 7);
                System.Console.WriteLine();
                System.Console.WriteLine($"O dado rolou {Dice2}");
                System.Console.WriteLine();

                CPU += Dice2;
                if (CPU == 5 || CPU == 10 || CPU == 15 || CPU == 20)
                {
                    System.Console.WriteLine($"\nBonus de avanço: {BonusRoll}");
                    CPU += BonusRoll;
                }
                else if (CPU == 7 || CPU == 13 || CPU == 20)
                {
                    System.Console.WriteLine($"\nPenalidade! Computador volta {Penalty} casas");
                    CPU -= Penalty;
                }

                if (CPU < FinishLine)
                {
                    System.Console.WriteLine($"Computador está na posição {CPU} de {FinishLine}");
                }
                if (CPU >= FinishLine)
                {
                    System.Console.WriteLine("Que pena o computador alcançou a linha de chegada primeiro!");
                    Round = false;
                    System.Console.WriteLine("Pressione ENTER para continuar...");
                    System.Console.ReadKey();
                    continue;
                }
            }

            System.Console.WriteLine("Deseja continuar?");
            string? Retry = Console.ReadLine()?.ToUpper();
            if (Retry != "S")
                break;
        }
    }
}