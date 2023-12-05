using System.Diagnostics;
using System.Text.RegularExpressions;

namespace _5;

class Program
{
    // private const string filePath = "exampleInput.txt";
    private const string filePath = "input.txt";

    class SeedMapper
    {
        public double SourceRangeStart { get; set; }
        public double SourceRangeEnd { get; set; }
        public double DestinationRangeStart { get; set; }
        public double DestinationRangeEnd { get; set; }
    }

    static void Main(string[] args)
    {
        // Part1();
        Part2Inverse();
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
                }
            }
            results.Add(currentSource);
        }
        Console.WriteLine(results.Min());
    }

    static void Part2()
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

        var seedDictionary = new Dictionary<double, double>();

        double seedToAddTo = -1;
        foreach (var seed in definitions["seeds:"][0].Split(" "))
        {
            if (seedToAddTo >= 0)
            {
                seedDictionary[seedToAddTo] = double.Parse(seed);
                seedToAddTo = -1;
            }
            else
            {
                seedToAddTo = double.Parse(seed);
                seedDictionary.Add(seedToAddTo, 0);
            }
        }

        var results = new List<double>();

        // foreach (var seed in seedDictionary)
        // {
        //     // double currentSource = double.Parse(seed);

        //     foreach (var item in definitions)
        //     {
        //         if (item.Key != "seeds:")
        //         {
        //             foreach (var value in item.Value)
        //             {
        //                 var valuesList = value.Split(" ");
        //                 var destinationRangeStart = double.Parse(valuesList[0]);
        //                 var sourceRangeStart = double.Parse(valuesList[1]);
        //                 var rangeLength = double.Parse(valuesList[2]);

        //                 if (currentSource >= sourceRangeStart && currentSource <= (sourceRangeStart + rangeLength))
        //                 {
        //                     double diffRange = (sourceRangeStart + rangeLength) - currentSource;
        //                     double destination = (destinationRangeStart + rangeLength) - diffRange;
        //                     currentSource = destination;
        //                     break;
        //                 }
        //             }
        //             Console.WriteLine(currentSource);
        //         }
        //     }
        //     // results.Add(currentSource);
        // }

        Console.WriteLine(results.Min());
    }

    static void Part2Inverse()
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

        var seedDictionary = new Dictionary<double, double>();

        double seedToAddTo = -1;
        foreach (var seed in definitions["seeds:"][0].Split(" "))
        {
            if (seedToAddTo >= 0)
            {
                seedDictionary[seedToAddTo] = double.Parse(seed);
                seedToAddTo = -1;
            }
            else
            {
                seedToAddTo = double.Parse(seed);
                seedDictionary.Add(seedToAddTo, 0);
            }
        }

        var seedMapperDictionary = new Dictionary<string, List<SeedMapper>>();

        foreach (var item in definitions)
        {
            if (item.Key != "seeds:")
            {
                seedMapperDictionary.Add(item.Key, new List<SeedMapper>());
                foreach (var value in item.Value)
                {
                    var valuesList = value.Split(" ");
                    var destinationRangeStart = double.Parse(valuesList[0]);
                    var sourceRangeStart = double.Parse(valuesList[1]);
                    var rangeLength = double.Parse(valuesList[2]);

                    seedMapperDictionary[item.Key].Add(new SeedMapper()
                    {
                        SourceRangeStart = sourceRangeStart,
                        SourceRangeEnd = (sourceRangeStart + rangeLength),
                        DestinationRangeStart = destinationRangeStart,
                        DestinationRangeEnd = (destinationRangeStart + rangeLength),
                    });
                }
            }
        }

        double lowestNumber = -1;
        foreach (var seed in seedDictionary)
        {
            lowestNumber = TraverseTree(seed.Value, seed.Key, seedMapperDictionary, "seed-to-soil map:", lowestNumber);
        }

        Console.WriteLine(lowestNumber);
    }



    static double TraverseTree(double start, double end, Dictionary<string, List<SeedMapper>> seedMapperDictionary, string currentIteration, double lowestNumber)
    {
        var item = seedMapperDictionary[currentIteration];
        foreach (var seedMapper in item)
        {
            if ((start <= seedMapper.SourceRangeEnd && end >= seedMapper.SourceRangeStart))
            {
                // start = seedMapper.DestinationRangeStart;
                // end = seedMapper.DestinationRangeEnd;

                // need to set the actual values that are within the range as start and end
                if (start > seedMapper.SourceRangeStart)
                {
                    var diff = (start - seedMapper.SourceRangeStart);
                    start = seedMapper.DestinationRangeStart + diff;
                }

                if (end < seedMapper.SourceRangeEnd)
                {
                   var diff = (seedMapper.SourceRangeEnd - end);
                   end = seedMapper.DestinationRangeEnd - diff;
                }

                string nextIteration = "";

                switch (currentIteration)
                {
                    case "seed-to-soil map:":
                        nextIteration = "soil-to-fertilizer map:";
                        break;
                    case "soil-to-fertilizer map:":
                        nextIteration = "fertilizer-to-water map:";
                        break;
                    case "fertilizer-to-water map:":
                        nextIteration = "water-to-light map:";
                        break;
                    case "water-to-light map:":
                        nextIteration = "light-to-temperature map:";
                        break;
                    case "light-to-temperature map:":
                        nextIteration = "temperature-to-humidity map:";
                        break;
                    case "temperature-to-humidity map:":
                        nextIteration = "humidity-to-location map:";
                        break;
                }


                if (currentIteration == "humidity-to-location map:")
                {
                    if (start > -1 && lowestNumber < start)
                    {
                        lowestNumber = start;
                    }
                }
                else
                {
                    var possibleLowest = TraverseTree(start, end, seedMapperDictionary, nextIteration, lowestNumber);
                    if (possibleLowest > -1 && lowestNumber < possibleLowest)
                    {
                        lowestNumber = start;
                    }
                }

            }
        }
        return lowestNumber;
    }

}
