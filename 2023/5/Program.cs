using System.Text.RegularExpressions;

namespace _5;

class Program
{
    private const string filePath = "input.txt";

    static void Main(string[] args)
    {
        Part1();
    }

    static void Part1()
    {
        var input = File.ReadAllLines(filePath);

        var definitions = new Dictionary<string, List<string>>();

        string currentDefinition = "";
        foreach (var item in input.Where(x => !string.IsNullOrWhiteSpace(x)))
        {
            if (!Regex.IsMatch(item, @"\d"))
            {
                currentDefinition = item;
                definitions.Add(currentDefinition, new List<string>());
            }
            else
            {
                definitions[currentDefinition].Add(item);
            }
        }

        var results = new List<double>();

        foreach (var seed in definitions["seeds:"][0].Split(" "))
        {
            double currentSource = double.Parse(seed);

            foreach (var item in definitions)
            {
                if (item.Key != "seeds:")
                {
                    foreach (var value in item.Value)
                    {
                        var valuesList = value.Split(" ");
                        var destinationRangeStart = double.Parse(valuesList[0]);
                        var sourceRangeStart = double.Parse(valuesList[1]);
                        var rangeLength = double.Parse(valuesList[2]);

                        if (currentSource >= sourceRangeStart && currentSource <= (sourceRangeStart + rangeLength))
                        {
                            double diffRange = (sourceRangeStart + rangeLength) - currentSource;
                            double destination = (destinationRangeStart + rangeLength) - diffRange;
                            currentSource = destination;
                            break;
                        }
                    }
                    Console.WriteLine(currentSource);
                }
            }
            results.Add(currentSource);
        }

        Console.WriteLine(results.Min());
    }
}
