using AdventOfCode;

Console.WriteLine("Hello, Day 1!");

var maxTotalCals= 0;
var currentTotalCals = 0;

foreach(var input in InputParser.ParseLines("./Inputs/Input.txt"))
{
    if(string.IsNullOrEmpty(input))
    {
        if(currentTotalCals > maxTotalCals)
        {
            maxTotalCals = currentTotalCals;
        }

        currentTotalCals = 0;
        continue;
    }

    currentTotalCals += Int32.Parse(input);
}

// Check for any left over after last line is parsed.
if (currentTotalCals > maxTotalCals)
{
    maxTotalCals = currentTotalCals;
}

Console.WriteLine($"Max total cals = {maxTotalCals}");