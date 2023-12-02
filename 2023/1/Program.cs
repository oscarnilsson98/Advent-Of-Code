namespace _1;

class Program
{
    private const string filePath = "./input.txt";

    static void Main(string[] args)
    {
        var numberList = new List<string>();

        try
        {
            // Open the file with a StreamReader
            using var reader = new StreamReader(filePath);

            // Read the file line by line until the end
            while (!reader.EndOfStream)
            {
                // Read the next line from the file
                string line = reader.ReadLine();

                var findStuffClass = new List<FindClass>();

                Console.WriteLine(line);

                // part 2
                line = line.Replace("one", "oonee");
                line = line.Replace("two", "ttwoo");
                line = line.Replace("three", "tthreee");
                line = line.Replace("four", "ffourr");
                line = line.Replace("five", "ffivee");
                line = line.Replace("six", "ssixx");
                line = line.Replace("seven", "ssevenn");
                line = line.Replace("eight", "eeightt");
                line = line.Replace("nine", "nninee");

                line = line.Replace("one", "1");
                line = line.Replace("two", "2");
                line = line.Replace("three", "3");
                line = line.Replace("four", "4");
                line = line.Replace("five", "5");
                line = line.Replace("six", "6");
                line = line.Replace("seven", "7");
                line = line.Replace("eight", "8");
                line = line.Replace("nine", "9");

                Console.WriteLine(line);

                var lineArray = line.ToCharArray();;
                int firstNumber = 0;
                int lastNumber = 0;

                foreach (var item in lineArray)
                {
                    if (int.TryParse(item.ToString(), out firstNumber))
                    {
                        break;
                    }
                }

                foreach (var item in lineArray.Reverse())
                {
                    if (int.TryParse(item.ToString(), out lastNumber))
                    {
                        break;
                    }
                }

                string totalLineNumber = $"{firstNumber}{lastNumber}";

                Console.WriteLine(totalLineNumber);

                numberList.Add(totalLineNumber);
            }
            
            Console.WriteLine(numberList.Select(x => int.Parse(x)).Sum());
        }
        catch (IOException e)
        {
            // Handle any exceptions that may occur during file reading
            Console.WriteLine($"An error occurred while reading the file: {e.Message}");
        }
    }
}
