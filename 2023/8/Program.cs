namespace _8;

class Program
{
    private const string filePath = "./input.txt";
    static void Main()
    {
        Part1();
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

            // reset
            if (currentDirectionIndex == (directionsString.Length - 1))
            {
                currentDirectionIndex = 0;
            }
            else
            {
                currentDirectionIndex++;
            }

            roundsTaken++;
        }

        Console.WriteLine(roundsTaken);
    }
}
