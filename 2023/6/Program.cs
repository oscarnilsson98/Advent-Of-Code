using System.Linq;

namespace _6;

class Program
{
    private const string filePath = "input.txt";

    static void Main(string[] args)
    {
        Part1();
    }

    static void Part1()
    {
        int result = 1;

        var constraints = new List<(int Id, int Time, int Distance)>
        {
            (1, 49, 298),
            (2, 78, 1185),
            (3, 79, 1066),
            (2, 80, 1181),
        };

        var wins = new List<(int Id, int wins)>();

        foreach (var (Id, Time, Distance) in constraints)
        {
            int iterationWins = 0;
            for (int i = 0; i < Time; i++)
            {
                int boatTraveled = i * (Time - i);
                if (boatTraveled > Distance)
                {
                    iterationWins++;
                }
            }
            wins.Add((Id, iterationWins));
        }

        foreach (var win in wins)
        {
            result *= win.wins;
        }

        Console.WriteLine(result);
    }
}
