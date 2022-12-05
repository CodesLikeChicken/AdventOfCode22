using AdventOfCode;
using System.Diagnostics;

var day = 4;
int answer = 0;

Console.WriteLine($"Hello, Day {day}");

// Do part 1 here;
foreach(var input in InputParser.ParseLines("./Inputs/Input.txt"))
{
    var sets = input.Split(',');
    var ranges = sets.Select(set => set.Split("-").Select(int.Parse).ToList()).ToList();

    var sortedSets = ranges
        .OrderBy(range => range[0])
        .ThenByDescending(range => range[1]).ToList();

    if ((sortedSets[0][1] >= sortedSets[1][1]))
    {
        answer++;
    }   

    Console.WriteLine();
}

Console.WriteLine($"Part 1 answer = {answer}");

// Do part 2 here:
answer= 0;
foreach (var input in InputParser.ParseLines("./Inputs/Input.txt"))
{
    var sets = input.Split(',');
    var ranges = sets.Select(set => set.Split("-").Select(int.Parse).ToList()).ToList();

    var sortedSets = ranges
        .OrderBy(range => range[0])
        .ThenByDescending(range => range[1]).ToList();

    if ((sortedSets[0][1] >= sortedSets[1][0]))
    {
        answer++;
    }
}

Console.WriteLine($"Part 2 answer = {answer}");

string toString(List<int> ints)
{
    return string.Join(',', ints);
}