using AdventOfCode;

string day = "3";
int answer = 0;

Console.WriteLine($"Hello, Day {day}");

// Do part 1 here;
foreach (var input in InputParser.ParseLines("./Inputs/Input.txt"))
{
    var inputLength = input.Length;
    var first = input.Substring(0, inputLength/2);
    var second = input.Substring(inputLength / 2, inputLength / 2);

    var match = findDuplicate(first, second);
    var matchValue = value(match);
    Console.WriteLine($"{match},{matchValue} in {input}");

    answer += matchValue;

    char findDuplicate(string first, string second)
    {
        foreach(var letter in second)
        {
            var match = first.IndexOf(letter);

            if(match != -1)
            {
                return letter;
            }
        }

        throw new KeyNotFoundException();
    }

    int value(char letter)
    {
        if(letter >= 'a' && letter <= 'z')
        {
            return 1 + letter - 'a';
        }
        else
        {
            return 27 + letter - 'A';
        }
    }

}

Console.WriteLine($"Part 1 answer = {answer}");

// Do part 2 here:
foreach (var input in InputParser.ParseLines("./Inputs/Input.txt"))
{

}

Console.WriteLine($"Part 2 answer = {answer}");