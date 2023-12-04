namespace _4;

class Program
{
    private const string filePath = "./input.txt";

    static void Main(string[] args)
    {
        // Part1();
        // Part2NotWorking();
        Part2();
    }

    static void Part1()
    {
        using var reader = new StreamReader(filePath);

        int total = 0;

        int row = 0;

        while (!reader.EndOfStream)
        {
            row++;
            string line = reader.ReadLine();

            var winningNumbers = line.Split(":")[1].Split("|")[0].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var scratchedNumbers = line.Split(":")[1].Split("|")[1].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            int points = 0;

            foreach (var number in winningNumbers)
            {
                if (scratchedNumbers.Any(x => x == number))
                {
                    Console.WriteLine(row);
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

    static void Part2NotWorking()
    {
        var input = File.ReadAllLines(filePath);

        int total = 0;

        var copies = new Dictionary<int, int>();

        copies[0] = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var line = input[i];

            if (copies.TryGetValue(i, out int currentCopy))
            {
                total += currentCopy + 1;
            }
            else
            {
                total++;
            }

            var winningNumbers = line.Split(":")[1].Split("|")[0].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var scratchedNumbers = line.Split(":")[1].Split("|")[1].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            int matches = 0;
            foreach (var number in winningNumbers)
            {
                if (scratchedNumbers.Any(x => x == number))
                {
                    matches++;
                }
            }
            // for (int set = 1; set <= matches; set++)
            var start = i + 1;
            for (int set = start; set < start + matches; set++)
            {
                var position = i + set;
                copies.TryAdd(position, 0);
                copies[position] = copies[position] + 1;
            }
        }

        Console.WriteLine(total);
    }

    static void Part2()
    {
        var input = File.ReadAllLines(filePath);
        var tickets = new Dictionary<int, (int copies, int newTicket)>();
        var index = 1;
        foreach (var item in input)
        {
            var split = item.Split('|', StringSplitOptions.TrimEntries);
            var winning = split[0].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Skip(2);
            var ticketNumbers = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var matches = ticketNumbers.Length - ticketNumbers.Except(winning).Count();
            tickets.Add(index, (1, matches));
            index++;
        }
        foreach (var item in tickets)
        {
            var start = item.Key + 1;
            var copiesToAdd = item.Value.copies;
            for (int i = start; i < start + item.Value.newTicket; i++)
            {
                var (copies, newTicket) = tickets[i];
                tickets[i] = (copies + copiesToAdd, newTicket);
            }
        }
        Console.WriteLine(tickets.Values.Sum(v => v.copies));
    }
}
