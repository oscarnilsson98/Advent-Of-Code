namespace _15;

class Program
{
    // private const string filePath = "./exampleInput.txt";
    private const string filePath = "./input.txt";

    static void Main()
    {
        Part1();
        Part2();
    }

    static void Part1()
    {
        var input = File.ReadAllLines(filePath)[0].Split(",");

        var totalSum = 0;
        foreach (var step in input)
        {
            var currentValue = 0;
            foreach (var character in step)
            {
                // Determine the ASCII code for the current character of the string.
                var asciiCode = (int)character;

                // Increase the current value by the ASCII code you just determined.
                currentValue += asciiCode;

                // Set the current value to itself multiplied by 17.
                currentValue *= 17;

                // Set the current value to the remainder of dividing itself by 256.
                currentValue %= 256;
            }
            totalSum += currentValue;
        }

        Console.WriteLine($"Total Sum: {totalSum}");
    }

    static void Part2()
    {
        var input = File.ReadAllLines(filePath)[0].Split(",");

        var boxes = new Dictionary<int, List<(string label, int lens)>>();

        for (int i = 0; i < 256; i++)
        {
            boxes.Add(i, []);
        }

        foreach (var step in input)
        {
            var boxKey = 0;

            string label = "";
            var move = '.';
            for (int i = 0; i < step.Length; i++)
            {
                var character = step[i];
                if (character == '=' || character == '-')
                {
                    move = character;
                    break;
                }

                var asciiCode = (int)character;
                boxKey += asciiCode;
                boxKey *= 17;
                boxKey %= 256;

                label += character;
            }

            var box = boxes.First(x => x.Key == boxKey);

            if (move == '=')
            {
                var lens = int.Parse(step.Split('=')[1]);
                if (box.Value.Where(x => x.label == label).Any())
                {
                    var valueIndex = box.Value.FindIndex(x => x.label == label);
                    boxes[boxKey][valueIndex] = (label, lens);
                }
                else
                {
                    boxes[boxKey].Add((label, lens));
                }
            }
            else if (move == '-')
            {
                if (box.Value.Where(x => x.label == label).Any())
                {
                    boxes[boxKey] = boxes[boxKey].Where(x => x.label != label).ToList();
                }
            }
        }

        int total = 0;
        var boxesWithValues = boxes.SelectMany(x => x.Value);
        foreach (var (label, lens) in boxesWithValues)
        {
            var box = boxes.First(x => x.Value.Where(v => v.label == label).Any());
            var boxPosition = 1 + box.Key;
            var slot = box.Value.FindIndex(x => x.label == label) + 1;
            total += boxPosition * slot * lens;
        }

        Console.WriteLine(total);
    }
}
