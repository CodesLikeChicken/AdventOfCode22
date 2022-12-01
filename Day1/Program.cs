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

// Part 2, get top three total cals.

var allCalTotals = new List<int>();

// Reset data
currentTotalCals = 0;

foreach (var input in InputParser.ParseLines("./Inputs/Input.txt"))
{
    if (string.IsNullOrEmpty(input))
    {
        allCalTotals.Add(currentTotalCals);

        currentTotalCals = 0;
        continue;
    }

    currentTotalCals += Int32.Parse(input);
}

allCalTotals.Add(currentTotalCals);

// Sort decending
allCalTotals.Sort((x, y) => y.CompareTo(x));

var topThreeTotal = 0;
for(int i = 0; i < 3; i++)
{
    var totalCal = allCalTotals[i];

    Console.WriteLine($"Max total cals {i + 1} = {totalCal}");

    topThreeTotal += totalCal;
}

Console.WriteLine($"Top three total = {topThreeTotal}");

Console.WriteLine("All Done");