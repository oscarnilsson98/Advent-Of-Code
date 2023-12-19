namespace _16;

class Program
{
    // private const string filePath = "./exampleInput.txt";
    private const string filePath = "./input.txt";

    private static int rowBorder = -1;
    private static int columnBorder = -1;

    static void Main()
    {
        Part1();
        Part2();
    }

    static void Part1()
    {
        var input = File.ReadAllLines(filePath);

        rowBorder = input.Length - 1;
        columnBorder = input[0].Length - 1;

        HashSet<(int row, int column, char direction)> passedSpots = [];

        passedSpots = MoveRight(input, 0, -1, passedSpots);

        Console.WriteLine(passedSpots.Select(x => new { x.row, x.column }).Distinct().Count());
    }

    static void Part2()
    {
        var input = File.ReadAllLines(filePath);

        rowBorder = input.Length - 1;
        columnBorder = input[0].Length - 1;

        var allTriesScores = new List<int>();

        // from above
        for (int i = 0; i < input[0].Length; i++)
        {
            HashSet<(int row, int column, char direction)> passedSpots = [];

            passedSpots = MoveDown(input, -1, i, passedSpots);

            allTriesScores.Add(passedSpots.Select(x => new { x.row, x.column }).Distinct().Count());
        }
        // from below
        for (int i = 0; i < input[0].Length; i++)
        {
            HashSet<(int row, int column, char direction)> passedSpots = [];

            passedSpots = MoveUp(input, rowBorder + 1, i, passedSpots);

            allTriesScores.Add(passedSpots.Select(x => new { x.row, x.column }).Distinct().Count());
        }
        // from left
        for (int i = 0; i < input.Length; i++)
        {
            HashSet<(int row, int column, char direction)> passedSpots = [];

            passedSpots = MoveRight(input, i, -1, passedSpots);

            allTriesScores.Add(passedSpots.Select(x => new { x.row, x.column }).Distinct().Count());
        }
        // from right
        for (int i = 0; i < input.Length; i++)
        {
            HashSet<(int row, int column, char direction)> passedSpots = [];

            passedSpots = MoveLeft(input, i, columnBorder + 1, passedSpots);

            allTriesScores.Add(passedSpots.Select(x => new { x.row, x.column }).Distinct().Count());
        }

        Console.WriteLine(allTriesScores.Max());
    }

    static HashSet<(int row, int column, char direction)> MoveUp(string[] input, int previousRow, int previousColumn, HashSet<(int row, int column, char direction)> passedSpots)
    {
        int row = previousRow - 1;
        int column = previousColumn;

        if (row < 0)
            return passedSpots;

        if (!passedSpots.Add((row, column, '^')))
            return passedSpots;

        switch (input[row][column])
        {
            case '.':
                return MoveUp(input, row, column, passedSpots);
            case '/':
                return MoveRight(input, row, column, passedSpots);
            case '\\':
                return MoveLeft(input, row, column, passedSpots);
            case '|':
                return MoveUp(input, row, column, passedSpots);
            case '-':
                passedSpots = MoveLeft(input, row, column, passedSpots);
                return MoveRight(input, row, column, passedSpots);
        }

        throw new Exception("Should've found a way while moving up...");
    }

    static HashSet<(int row, int column, char direction)> MoveDown(string[] input, int previousRow, int previousColumn, HashSet<(int row, int column, char direction)> passedSpots)
    {
        int row = previousRow + 1;
        int column = previousColumn;

        if (row > rowBorder)
            return passedSpots;

        if (!passedSpots.Add((row, column, 'v')))
            return passedSpots;

        switch (input[row][column])
        {
            case '.':
                return MoveDown(input, row, column, passedSpots);
            case '/':
                return MoveLeft(input, row, column, passedSpots);
            case '\\':
                return MoveRight(input, row, column, passedSpots);
            case '|':
                return MoveDown(input, row, column, passedSpots);
            case '-':
                passedSpots = MoveLeft(input, row, column, passedSpots);
                return MoveRight(input, row, column, passedSpots);
        }

        throw new Exception("Should've found a way while moving down...");
    }

    static HashSet<(int row, int column, char direction)> MoveLeft(string[] input, int previousRow, int previousColumn, HashSet<(int row, int column, char direction)> passedSpots)
    {
        int row = previousRow;
        int column = previousColumn - 1;

        if (column < 0)
            return passedSpots;

        if (!passedSpots.Add((row, column, '<')))
            return passedSpots;

        switch (input[row][column])
        {
            case '.':
                return MoveLeft(input, row, column, passedSpots);
            case '/':
                return MoveDown(input, row, column, passedSpots);
            case '\\':
                return MoveUp(input, row, column, passedSpots);
            case '|':
                passedSpots = MoveUp(input, row, column, passedSpots);
                return MoveDown(input, row, column, passedSpots);
            case '-':
                return MoveLeft(input, row, column, passedSpots);
        }

        throw new Exception("Should've found a way while moving up...");
    }

    static HashSet<(int row, int column, char direction)> MoveRight(string[] input, int previousRow, int previousColumn, HashSet<(int row, int column, char direction)> passedSpots)
    {
        int row = previousRow;
        int column = previousColumn + 1;

        if (column > columnBorder)
            return passedSpots;

        if (!passedSpots.Add((row, column, '>')))
            return passedSpots;

        switch (input[row][column])
        {
            case '.':
                return MoveRight(input, row, column, passedSpots);
            case '/':
                return MoveUp(input, row, column, passedSpots);
            case '\\':
                return MoveDown(input, row, column, passedSpots);
            case '|':
                passedSpots = MoveUp(input, row, column, passedSpots);
                return MoveDown(input, row, column, passedSpots);
            case '-':
                return MoveRight(input, row, column, passedSpots);
        }

        throw new Exception("Should've found a way while moving right...");
    }
}
