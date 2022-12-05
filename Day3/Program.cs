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
    var matchValue = evaluate(match);
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
}

Console.WriteLine($"Part 1 answer = {answer}");

// Do part 2 here:
answer = 0;
var inputs = InputParser.ParseLines("./Inputs/Input.txt").ToList();

for(int i = 0 ; i < inputs.Count; i += 3)
{
    var commonLetter = inputs[i]
        .Intersect(inputs[i + 1])
        .Intersect(inputs[i + 2])
        .First();

    answer += evaluate(commonLetter);
}

Console.WriteLine($"Part 2 answer = {answer}");

int evaluate(char letter)
{
    if (letter >= 'a' && letter <= 'z')
    {
        return 1 + letter - 'a';
    }
    else
    {
        return 27 + letter - 'A';
    }
}