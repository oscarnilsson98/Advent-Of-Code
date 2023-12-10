namespace _10;

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

        int sy = 0;
        int sx = 0;

        for (int x = 0; x < input.Length; x++)
        {
            var row = input[x];
            for (int y = 0; y < row.Length; y++)
            {
                if (row[y] == 'S')
                {
                    sx = x;
                    sy = y;
                }
            }
        }

        int totalRounds = 0;

        (int currentX, int currentY, int previousX, int previousY) = FindNextDirectionBasedOnPreviousPipe(input, sx, sy, -1, -1);
        totalRounds++;
    
        var iterate = currentX != sx || currentY != sy;
        while (iterate)
        {
            (currentX, currentY, previousX, previousY) = FindNextDirectionBasedOnPreviousPipe(input, currentX, currentY, previousX, previousY);
            totalRounds++;
            iterate = currentX != sx || currentY != sy;
        }

        Console.WriteLine(totalRounds / 2);
    }

    static (int newX, int newY, int previousX, int previousY) FindNextDirectionBasedOnPreviousPipe(string[] input, int currentX, int currentY, int previousX, int previousY)
    {
        var currentPipe = input[currentX][currentY];

        if (currentPipe == '|' || currentPipe == 'S')
        {
            if (GoUp(input, currentX, currentY, previousX, previousY))
            {
                return (currentX - 1, currentY, currentX, currentY);
            }
            if (GoDown(input, currentX, currentY, previousX, previousY))
            {
                return (currentX + 1, currentY, currentX, currentY);
            }
        }

        if (currentPipe == '-' || currentPipe == 'S')
        {
            if (GoLeft(input, currentX, currentY, previousX, previousY))
            {
                return (currentX, currentY - 1, currentX, currentY);
            }
            if (GoRight(input, currentX, currentY, previousX, previousY))
            {
                return (currentX, currentY + 1, currentX, currentY);
            }
        }

        if (currentPipe == 'L' || currentPipe == 'S')
        {
            if (GoUp(input, currentX, currentY, previousX, previousY))
            {
                return (currentX - 1, currentY, currentX, currentY);
            }
            if (GoRight(input, currentX, currentY, previousX, previousY))
            {
                return (currentX, currentY + 1, currentX, currentY);
            }
        }

        if (currentPipe == 'J' || currentPipe == 'S')
        {
            if (GoUp(input, currentX, currentY, previousX, previousY))
            {
                return (currentX - 1, currentY, currentX, currentY);
            }
            if (GoLeft(input, currentX, currentY, previousX, previousY))
            {
                return (currentX, currentY - 1, currentX, currentY);
            }
        }

        if (currentPipe == '7' || currentPipe == 'S')
        {
            if (GoLeft(input, currentX, currentY, previousX, previousY))
            {
                return (currentX, currentY - 1, currentX, currentY);
            }
            if (GoDown(input, currentX, currentY, previousX, previousY))
            {
                return (currentX + 1, currentY, currentX, currentY);
            }
        }

        if (currentPipe == 'F' || currentPipe == 'S')
        {
            if (GoRight(input, currentX, currentY, previousX, previousY))
            {
                return (currentX, currentY + 1, currentX, currentY);
            }
            if (GoDown(input, currentX, currentY, previousX, previousY))
            {
                return (currentX + 1, currentY, currentX, currentY);
            }
        }

        throw new Exception("A Path should be found by now");
    }

    static bool GoUp(string[] input, int currentX, int currentY, int previousX, int previousY)
    {
        var newX = currentX - 1;
        if (newX < 0 || newX > input.Length)
        {
            return false;
        }

        if (newX != previousX || currentY != previousY)
        {
            var above = input[newX][currentY];
            if ((above == '|' || above == '7' || above == 'F' || above == 'S') && above != '.')
            {
                Console.WriteLine($"above {above}");
                return true;
            }
        }
        return false;
    }

    static bool GoLeft(string[] input, int currentX, int currentY, int previousX, int previousY)
    {
        var newY = currentY - 1;
        if (newY < 0 || newY > input[currentX].Length)
        {
            return false;
        }

        if (currentX != previousX || newY != previousY)
        {
            var left = input[currentX][newY];
            if ((left == '-' || left == 'L' || left == 'F' || left == 'S') && left != '.')
            {
                Console.WriteLine($"left {left}");
                return true;
            }
        }
        return false;
    }

    static bool GoRight(string[] input, int currentX, int currentY, int previousX, int previousY)
    {
        var newY = currentY + 1;
        if (newY < 0 || newY > input[currentX].Length)
        {
            return false;
        }

        if (currentX != previousX || newY != previousY)
        {
            var right = input[currentX][newY];
            if ((right == '-' || right == 'J' || right == '7' || right == 'S') && right != '.')
            {
                Console.WriteLine($"right {right}");
                return true;
            }
        }
        return false;
    }

    static bool GoDown(string[] input, int currentX, int currentY, int previousX, int previousY)
    {
        var newX = currentX + 1;
        if (newX < 0 || newX > input.Length)
        {
            return false;
        }

        if (newX != previousX || currentY != previousY)
        {
            var below = input[newX][currentY];
            if ((below == '|' || below == 'L' || below == 'J' || below == 'S') && below != '.')
            {
                Console.WriteLine($"below {below}");
                return true;
            }
        }
        return false;
    }
}
