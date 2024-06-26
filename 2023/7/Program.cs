﻿namespace _7;

class Program
{
    private const string filePath = "./input.txt";

    enum HandType
    {
        fiveOfAKind = 1,
        fourOfAKind = 2,
        fullHouse = 3,
        threeOfAKind = 4,
        twoPair = 5,
        onePair = 6,
        highCard = 7,
    }

    static void Main(string[] args)
    {
        Part1();
        Part2();
    }

    static void Part1()
    {
        var input = File.ReadAllLines(filePath);

        var handDictionary = new Dictionary<string, (int bid, int type)>();

        foreach (var item in input)
        {
            var hand = item.Split(" ")[0];
            var bid = int.Parse(item.Split(" ")[1]);
            var type = GetHandTypee(hand);

            handDictionary.Add(hand, (bid, (int)type));
        }

        var result = handDictionary
            .OrderByDescending(x => x.Value.type)
            .ThenBy(x => x.Key, new CustomComparer())
            .Select((x, index) => x.Value.bid * (index + 1))
            .Sum();

        Console.WriteLine(result);
    }

    static HandType GetHandTypee(string hand)
    {
        List<char> characters = [.. hand];

        var charDictionary = new Dictionary<char, int>();

        return GetHandTypeeFromDictionary(charDictionary);
    }

    static void Part2()
    {
        var input = File.ReadAllLines(filePath);

        var handDictionary = new Dictionary<string, (int bid, int type)>();

        foreach (var item in input)
        {
            var hand = item.Split(" ")[0];
            var bid = int.Parse(item.Split(" ")[1]);
            var type = GetHandTypeePart2(hand);

            handDictionary.Add(hand, (bid, type));
        }

        var result = handDictionary
            .OrderByDescending(x => x.Value.type)
            .ThenBy(x => x.Key, new CustomComparer())
            .Select((x, index) => x.Value.bid * (index + 1))
            .Sum();

        Console.WriteLine(result);
    }

    static int GetHandTypeePart2(string hand)
    {
        List<char> characters = [.. hand];

        var charDictionary = new Dictionary<char, int>();

        foreach (var p in characters.Distinct())
        {
            charDictionary.Add(p, characters.Where(x => x == p).Count());
        }

        var possibleTypes = new List<int>
        {
            (int)GetHandTypeeFromDictionary(charDictionary)
        };

        if (charDictionary.TryGetValue('J', out int value))
        {
            foreach (var current in charDictionary.Where(x => x.Key != 'J'))
            {
                var replacedCharDictionary = charDictionary.Where(x => x.Key != 'J').ToDictionary(entry => entry.Key, entry => entry.Value);

                replacedCharDictionary[current.Key] = current.Value + value;

                possibleTypes.Add((int)GetHandTypeeFromDictionary(replacedCharDictionary));
            }
        }

        var firsto = possibleTypes.OrderBy(x => x).First();

        return firsto;
    }

    static HandType GetHandTypeeFromDictionary(Dictionary<char, int> charDictionary)
    {
        if (charDictionary.Count == 1)
        {
            return HandType.fiveOfAKind;
        }

        if (charDictionary.Count == 2)
        {
            if (charDictionary.ContainsValue(4))
            {
                return HandType.fourOfAKind;
            }
            return HandType.fullHouse;
        }

        if (charDictionary.Count == 3)
        {
            if (charDictionary.ContainsValue(3))
            {
                return HandType.threeOfAKind;
            }
            return HandType.twoPair;
        }

        if (charDictionary.Count == 4)
        {
            return HandType.onePair;
        }

        return HandType.highCard;
    }
}

public class CustomComparer : IComparer<string>
{
    public readonly string customOrder = "AKQT98765432J";

    public int Compare(string? x, string? y)
    {
        for (int i = 0; i < x.Length; i++)
        {
            if (x[i] == y[i])
                continue;

            int indexX = customOrder.IndexOf(x[i]);
            int indexY = customOrder.IndexOf(y[i]);

            return indexY.CompareTo(indexX);
        }

        return 0;
    }
}