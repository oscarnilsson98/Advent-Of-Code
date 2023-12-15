namespace _14;

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

        var inputList = input.Select(x => x.ToCharArray().ToList()).ToList();

        for (int rowIndex = inputList.Count - 1; rowIndex >= 0; rowIndex--)
        {
            if (rowIndex == 0)
                continue;

            var nextRowIndex = rowIndex - 1;
            for (int colIndex = 0; colIndex < inputList[rowIndex].Count; colIndex++)
            {
                if (inputList[rowIndex][colIndex] == 'O')
                {
                    if (inputList[nextRowIndex][colIndex] == '.')
                    {
                        inputList[nextRowIndex][colIndex] = 'O';
                        inputList[rowIndex][colIndex] = '.';
                    }
                    else if (inputList[nextRowIndex][colIndex] == 'O')
                    {
                        inputList = TraverseAndMoveTheBouldersNorth(inputList, rowIndex, colIndex);
                        if (inputList[nextRowIndex][colIndex] == '.')
                        {
                            inputList[nextRowIndex][colIndex] = 'O';
                            inputList[rowIndex][colIndex] = '.';
                        }
                    }
                }
            }
        }

        var load = inputList.Count;
        var total = inputList.Select((x, i) => x.Where(x => x == 'O').Count() * (load - i)).Sum();
        Console.WriteLine(total);
    }


    static List<List<char>> TraverseAndMoveTheBouldersNorth(List<List<char>> inputList, int currentRowIndex, int colIndex)
    {
        var rowIndex = currentRowIndex - 1;
        if (rowIndex == 0)
            return inputList;
        var nextRowIndex = rowIndex - 1;

        if (inputList[rowIndex][colIndex] == 'O')
        {
            if (inputList[nextRowIndex][colIndex] == '.')
            {
                inputList[nextRowIndex][colIndex] = 'O';
                inputList[rowIndex][colIndex] = '.';
            }
            else if (inputList[nextRowIndex][colIndex] == 'O')
            {
                inputList = TraverseAndMoveTheBouldersNorth(inputList, rowIndex, colIndex);
                if (inputList[nextRowIndex][colIndex] == '.')
                {
                    inputList[nextRowIndex][colIndex] = 'O';
                    inputList[rowIndex][colIndex] = '.';
                }
            }
        }

        return inputList;
    }
}
