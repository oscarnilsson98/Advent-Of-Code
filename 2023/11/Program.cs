namespace _11;

class Program
{
    private const string filePath = "./input.txt";
    // private const string filePath = "./exampleInput.txt";

    static void Main()
    {
        Part1();
    }

    static void Part1()
    {
        var input = File.ReadAllLines(filePath);

        var expandedRowInput = new List<string>();
        foreach (var row in input)
        {
            expandedRowInput.Add(row);
            if (!row.Contains('#'))
            {
                expandedRowInput.Add(row);
            }
        }

        var expandedGalaxy = new List<List<char>>();
        for (int rowIndex = 0; rowIndex < expandedRowInput.Count; rowIndex++)
        {
            expandedGalaxy.Add([]);
        }
        for (int colIndex = 0; colIndex < expandedRowInput[0].Length; colIndex++)
        {
            var column = input.Select(x => x[colIndex]);
            for (int rowIndex = 0; rowIndex < expandedRowInput.Count; rowIndex++)
            {
                expandedGalaxy[rowIndex].Add(expandedRowInput[rowIndex][colIndex]);
            }
            if (!column.Contains('#'))
            {
                for (int rowIndex = 0; rowIndex < expandedRowInput.Count; rowIndex++)
                {
                    expandedGalaxy[rowIndex].Add(expandedRowInput[rowIndex][colIndex]);
                }
            }
        }

        int total = 0;

        var allGalaxiesWithPositions = new Dictionary<(int row, int column), List<(int row, int column)>>();
        for (int rowIndex = 0; rowIndex < expandedGalaxy.Count; rowIndex++)
        {
            var row = expandedGalaxy[rowIndex];
            for (int colIndex = 0; colIndex < row.Count; colIndex++)
            {
                var currentChar = row[colIndex];
                if (currentChar == '#')
                {
                    allGalaxiesWithPositions.Add((rowIndex, colIndex), []);
                }
            }
        }

        foreach (var galaxy in allGalaxiesWithPositions)
        {
            foreach (var galaxyToCheck in allGalaxiesWithPositions)
            {
                if (!galaxy.Value.Where(x => x.row == galaxyToCheck.Key.row && x.column == galaxyToCheck.Key.column).Any())
                {
                    galaxy.Value.Add((galaxyToCheck.Key.row, galaxyToCheck.Key.column));
                    allGalaxiesWithPositions.First(x => x.Key.row == galaxyToCheck.Key.row && x.Key.column == galaxyToCheck.Key.column).Value.Add((galaxy.Key.row, galaxy.Key.column));
                    total += Math.Abs(galaxy.Key.row - galaxyToCheck.Key.row) + Math.Abs(galaxy.Key.column - galaxyToCheck.Key.column);
                }
            }
        }
        Console.WriteLine(total);
    }
}
