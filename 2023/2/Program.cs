namespace _2;

class Program
{
    private const string filePath = "./input.txt";
    private const int maximumRedCubes = 12;
    private const int maximumGreenCubes = 13;
    private const int maximumBlueCubes = 14;

    static void Main(string[] args)
    {
        using var reader = new StreamReader(filePath);

        int total = 0;

        int index = 0;

        while (!reader.EndOfStream)
        {
            index++;

            string line = reader.ReadLine();

            string removedGame = line.Split(": ")[1];

            var sets = removedGame.Split(";");

            int redCubes = 0;
            int greenCubes = 0;
            int blueCubes = 0;

            foreach (var set in sets)
            {
                var cubes = set.Split(",");
                foreach (string cube in cubes)
                {
                    Console.WriteLine(cube);
                    if (cube.Contains("red"))
                    {
                        Console.WriteLine(int.Parse(cube.Replace("red", "").Trim()));
                        int amount = int.Parse(cube.Replace("red", "").Trim());
                        if (amount > redCubes)
                        {
                            redCubes = amount;
                        }
                    }
                    else if (cube.Contains("green"))
                    {
                        Console.WriteLine(int.Parse(cube.Replace("green", "").Trim()));
                        int amount = int.Parse(cube.Replace("green", "").Trim());
                        if (amount > greenCubes)
                        {
                            greenCubes = amount;
                        }
                    }
                    else if (cube.Contains("blue"))
                    {
                        Console.WriteLine(int.Parse(cube.Replace("blue", "").Trim()));
                        int amount = int.Parse(cube.Replace("blue", "").Trim());
                        if (amount > blueCubes)
                        {
                            blueCubes = amount;
                        }
                    }

                    Console.WriteLine($"{redCubes} {greenCubes} {blueCubes}");
                }
            }

            // part 1
            // if (redCubes <= maximumRedCubes && greenCubes <= maximumGreenCubes && blueCubes <= maximumBlueCubes)
            // {
            //     total += index;
            // }

            // part 2
            total += (redCubes * greenCubes * blueCubes);
        }
        
        Console.WriteLine(total);
    }
}
