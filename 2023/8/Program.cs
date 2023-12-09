namespace _8;

class Program
{
    private const string filePath = "./input.txt";
    static void Main()
    {
        Part1();
        Part2();
    }

    static void Part1()
    {
        var input = File.ReadAllLines(filePath);

        var directionsString = input[0];

        var transitionDefinitions = new Dictionary<string, (string LeftPath, string RightPath)>();
        for (int i = 2; i < input.Length; i++)
        {
            string entry = input[i].Split(" ")[0];
            string leftPath = input[i].Split("(")[1].Split(", ")[0];
            string rightPath = input[i].Split("(")[1].Split(", ")[1].Replace(")", "");
            transitionDefinitions.Add(entry, (leftPath, rightPath));
        }

        int roundsTaken = 0;

        var currentDirectionIndex = 0;
        var currentDirection = directionsString[currentDirectionIndex];
        string currentSpot = "AAA";
        while (currentSpot != "ZZZ")
        {
            currentDirection = directionsString[currentDirectionIndex];
            var currentPath = transitionDefinitions.Where(x => x.Key == currentSpot).First();

            currentSpot = currentDirection switch
            {
                'L' => currentPath.Value.LeftPath,
                _ => currentPath.Value.RightPath,
            };

            currentDirectionIndex = currentDirectionIndex == (directionsString.Length - 1) ? 0 : (currentDirectionIndex + 1);

            roundsTaken++;
        }

        Console.WriteLine(roundsTaken);
    }

    class CurrentSpotClass
    {
        public string Entry { get; set; } = "";
        public string CurrentSpot { get; set; } = "";
        public int TimeToZ { get; set; } = 0;
    }

    static void Part2()
    {
        var input = File.ReadAllLines(filePath);

        var directionsString = input[0];

        var transitionDefinitions = new Dictionary<string, (string LeftPath, string RightPath)>();
        for (int i = 2; i < input.Length; i++)
        {
            string entry = input[i].Split(" ")[0];
            string leftPath = input[i].Split("(")[1].Split(", ")[0];
            string rightPath = input[i].Split("(")[1].Split(", ")[1].Replace(")", "");
            transitionDefinitions.Add(entry, (leftPath, rightPath));
        }

        var currentDirectionIndex = 0;
        var currentDirection = directionsString[currentDirectionIndex];

        var currentSpots = new List<CurrentSpotClass>();

        foreach (var entry in transitionDefinitions.Keys)
        {
            if (entry.Last() == 'A')
            {
                currentSpots.Add(new CurrentSpotClass
                {
                    Entry = entry,
                    CurrentSpot = entry,
                });
            }
        }

        int roundsTaken = 0;
        while (currentSpots.Where(x => x.CurrentSpot.Last() != 'Z').Any())
        {
            roundsTaken++;
            currentDirection = directionsString[currentDirectionIndex];

            for (int i = 0; i < currentSpots.Count; i++)
            {
                var currentSpotObj = currentSpots[i];

                if (currentSpotObj.TimeToZ > 0)
                {
                    continue;
                }

                var currentPath = transitionDefinitions.Where(x => x.Key == currentSpotObj.CurrentSpot).First();

                currentSpots[i].CurrentSpot = currentDirection switch
                {
                    'L' => currentPath.Value.LeftPath,
                    _ => currentPath.Value.RightPath,
                };

                if (currentSpotObj.CurrentSpot.Last() == 'Z')
                {
                    currentSpots.First(x => x.Entry == currentSpotObj.Entry).TimeToZ = roundsTaken;
                }
            }

            currentDirectionIndex = currentDirectionIndex == (directionsString.Length - 1) ? 0 : (currentDirectionIndex + 1);
        }

        var longestTimeToZ = currentSpots.Select(x => x.TimeToZ).Max();
        long count = longestTimeToZ;

        while (!currentSpots.Select(x => x.TimeToZ).All(i => count % i == 0))
        {
            count += longestTimeToZ;
        }

        Console.WriteLine(count);
    }
}
