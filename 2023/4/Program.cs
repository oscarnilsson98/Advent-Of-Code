namespace _4;

class Program
{
    private const string filePath = "./input.txt";

    static void Main(string[] args)
    {
        Part1();
    }
    
    static void Part1()
    {
        using var reader = new StreamReader(filePath);

        int total = 0;

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();

            var winningNumbers = line.Split(":")[1].Split("|")[0].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var scratchedNumbers = line.Split(":")[1].Split("|")[1].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            int points = 0;

            foreach (var number in winningNumbers)
            {
                if (scratchedNumbers.Any(x => x == number))
                {
                    switch (points)
                    {
                        case 0:
                            points++;
                            break;
                        default:
                            points *= 2;
                            break;
                    }
                }
            }
            total += points;
        }

        Console.WriteLine(total);
    }
}
