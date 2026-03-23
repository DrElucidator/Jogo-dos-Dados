namespace jogoDosDados.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        UI.WelcomeMessage();

        const int FinishLine = 30;
        const int BonusRoll = 3;
        const int Penalty = 2;

        while (true)
        {
            Game.PlayRound(FinishLine, BonusRoll, Penalty);

            if (!UI.Retry())
                break;
        }
    }
}