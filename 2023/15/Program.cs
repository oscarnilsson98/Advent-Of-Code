namespace _15;

class Program
{
    // private const string filePath = "./easyExampleInput.txt";
    // private const string filePath = "./exampleInput.txt";
    private const string filePath = "./input.txt";

    static void Main()
    {
        Part1();
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
}
