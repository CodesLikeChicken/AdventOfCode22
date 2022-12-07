using AdventOfCode;

Console.WriteLine("Hello, Day 2!");

var totalScore = 0;

foreach(var input in InputParser.ParseLines("./Inputs/Input.txt"))
{
    var inputs = InputParser.SplitInput(input, new List<string> { " " });

    totalScore += EvaluatePair(inputs[0], inputs[1]);

    int EvaluatePair(string oponentPick, string myPick)
    {
        var totalScore = 0;

        switch (myPick)
        {
            case "X":
                totalScore += 1;
                totalScore += EvaluationOutcome(oponentPick, "A");
                break;
            case "Y":
                totalScore += 2;
                totalScore += EvaluationOutcome(oponentPick, "B");
                break;
            case "Z":
                totalScore += EvaluationOutcome(oponentPick, "C");
                totalScore += 3;
                break;
        }

        int EvaluationOutcome(string oponentPick, string myPick)
        {
            const int WIN = 6;
            const int LOSE = 0;
            const int DRAW = 3;

            switch ($"{oponentPick}{myPick}")
            {
                case "AA":
                case "BB":
                case "CC":
                    return DRAW;
                case "AB":
                case "BC":
                case "CA":
                    return WIN;
                default:
                    return LOSE;
            }
        }


        return totalScore;
    }
}

Console.WriteLine($"Part 1 total score = {totalScore}");

totalScore = 0;

foreach (var input in InputParser.ParseLines("./Inputs/Input.txt"))
{

    var inputs = InputParser.SplitInput(input, new List<string> { " " });

    totalScore += EvaluatePair(inputs[0], inputs[1]);

    int EvaluatePair(string oponentPick, string myStrategy)
    {
        const int WIN = 6;
        const int LOSE = 0;
        const int DRAW = 3;

        var totalScore = 0;

        int strategy = 0;

        switch (myStrategy)
        {
            case "X":
                strategy = LOSE;
                break;
            case "Y":
                strategy =  DRAW;
                break;
            case "Z":
                strategy = WIN;
                break;
        }

        totalScore += strategy + GetPickValue(oponentPick, strategy);

        int GetPickValue(string oponentPick, int strategy)
        {
            var strategyKey = oponentPick;

            switch(strategy)
            {
                case WIN:
                    strategyKey += $"W";
                    break;
                case LOSE:
                    strategyKey += $"L";
                    break;
                case DRAW:
                    strategyKey += $"D";
                    break;
            }

            switch (strategyKey)
            {
                // Choose Rock
                case "AD":
                case "BL":
                case "CW":
                    return 1;
                // Choose Paper
                case "BD":
                case "CL":
                case "AW":
                    return 2;
                // Choose Scissors
                default:
                    return 3;
            }
        }

        return totalScore;
    }
}

Console.WriteLine($"Part 2 total score = {totalScore}");