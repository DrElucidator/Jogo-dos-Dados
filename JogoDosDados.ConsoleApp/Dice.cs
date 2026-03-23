using System.Security.Cryptography;

namespace jogoDosDados.ConsoleApp;

public static class Dice
{
    public static int Roll(string player, int position, int bonus, int penalty, int finishLine)
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
            Console.WriteLine("Pressione ENTER para que o dado seja rolado novamente...");
            Console.ReadKey();
            return Roll(player, position, bonus, penalty, finishLine);
        }

        Console.WriteLine($"{player} está na posição {position} de {finishLine}");
        System.Console.WriteLine("Pressione ENTER para continuar...");
        System.Console.ReadKey();
        return position;
    }
}