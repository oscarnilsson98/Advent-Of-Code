namespace _13;

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

        var patternDictionary = new Dictionary<int, List<string>>();

        var currentPattern = 0;
        foreach (var item in input)
        {
            if (string.IsNullOrEmpty(item))
            {
                currentPattern++;
            }
            else
            {
                patternDictionary.TryAdd(currentPattern, []);
                patternDictionary[currentPattern].Add(item);
            }
        }

        var horizontalTotal = 0;
        var verticalTotal = 0;
        foreach (var item in patternDictionary)
        {
            var pattern = item.Value;

            horizontalTotal += CheckHorizontalMatch(pattern);
            verticalTotal += CheckVerticalMatch(pattern);
        }

        var total = (horizontalTotal * 100) + verticalTotal;
        Console.WriteLine(total);
    }

    static int CheckHorizontalMatch(List<string> pattern)
    {
        for (int y = 0; y < pattern.Count; y++)
        {
            if (y - 1 < 0)
                continue;

            var row = pattern[y];
            var previousRow = pattern[y - 1];
            if (row == previousRow)
            {
                var matched = true;
                var otherY = y;
                for (int by = y - 1; by >= 0; by--)
                {
                    if (otherY >= pattern.Count)
                        break;

                    if (pattern[by] != pattern[otherY])
                    {
                        matched = false;
                        break;
                    }
                    otherY++;
                }
                if (matched)
                {
                    return y;
                }
            }
        }

        return 0;
    }

    static int CheckVerticalMatch(List<string> pattern)
    {
        for (int x = 0; x < pattern[0].Length; x++)
        {
            var matching = 0;
            for (int y = 0; y < pattern.Count; y++)
            {
                var character = pattern[y][x];
                var previousColumngIndex = x - 1;
                if (previousColumngIndex >= 0)
                {
                    var previousCharacter = pattern[y][previousColumngIndex];
                    if (character == previousCharacter)
                    {
                        matching++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (matching == pattern.Count)
            {
                var matched = true;
                var otherX = x;
                for (int bx = x - 1; bx >= 0; bx--)
                {
                    if (otherX >= pattern[0].Length)
                    {
                        break;
                    }

                    var matchingB = 0;
                    for (int y = 0; y < pattern.Count; y++)
                    {
                        var character = pattern[y][bx];
                        var otherCharacter = pattern[y][otherX];
                        if (character == otherCharacter)
                        {
                            matchingB++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (matchingB != pattern.Count)
                    {
                        matched = false;
                        break;
                    }

                    otherX++;
                }
                if (matched)
                {
                    return x;
                }
            }
        }

        return 0;
    }
}
