﻿namespace _9;

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

        long total = 0;
        foreach (var line in input)
        {
            total += FindNextValue(line.Split(" ").Select(x => long.Parse(x)).ToArray());
        }

        Console.WriteLine(total);
    }

    static long FindNextValue(long[] numberArray)
    {
        var newNumberList = new List<long>();
        for (int i = 0; i < numberArray.Length; i++)
        {
            if ((i + 1) < numberArray.Length)
            {
                long difference = numberArray[i + 1] - numberArray[i];
                newNumberList.Add(difference);
            }
        }

        return newNumberList.Distinct().Count() switch
        {
            1 => numberArray.Last() + newNumberList.Last(),
            _ => numberArray.Last() + FindNextValue([.. newNumberList]),
        };
    }
}
