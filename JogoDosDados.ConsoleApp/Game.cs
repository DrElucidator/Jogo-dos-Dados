namespace jogoDosDados.ConsoleApp;

public static class Game
{
    public static void PlayRound(int finishLine, int bonusRoll, int penalty)
    {
        int p1Pos = 0; int cpu = 0;
        bool round = true;
        int currentPlayerTurn = 0;
        string[] players = { "Jogador", "Computador" };

        while (round)
        {
            string currentPlayer = players[currentPlayerTurn];

            if (currentPlayerTurn == 0) // Jogador
            {
                UI.Header(currentPlayer, p1Pos, cpu, finishLine);
                Console.WriteLine("\nPressione ENTER para jogar o dado...");
                Console.ReadKey();
                p1Pos = Dice.Roll("Jogador", p1Pos, bonusRoll, penalty, finishLine);

                if (p1Pos >= finishLine)
                {
                    Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                    round = false;
                }
            }
            else // CPU
            {
                UI.Header(currentPlayer, p1Pos, cpu, finishLine);
                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadKey();
                cpu = Dice.Roll("Computador", cpu, bonusRoll, penalty, finishLine);

                if (cpu >= finishLine)
                {
                    Console.WriteLine("Que pena, o computador alcançou a linha de chegada primeiro!");
                    round = false;
                }
            }

            currentPlayerTurn = (currentPlayerTurn + 1) % 2;
        }
    }
}