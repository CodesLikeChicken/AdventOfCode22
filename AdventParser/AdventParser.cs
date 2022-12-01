using System.Collections;
using System.Text;

namespace AdventOfCode
{
    public static class InputParser
    {
        public static List<string> SplitInput(
            string inputLine,
            List<string> inputTokens)
        {

            var finalToken = ',';

            while (inputLine.Contains(finalToken))
            {
                finalToken++;
            }

            var tokenizedString = new StringBuilder();
            tokenizedString.Append(inputLine);
            foreach (var token in inputTokens)
            {
                tokenizedString = tokenizedString.Replace(token, finalToken.ToString());
            }

            return tokenizedString.ToString().Split(finalToken).Where(value => !string.IsNullOrEmpty(value)).ToList();
        }

        public static void Parse(string inputFile, List<string> inputTokens)
        {
            var inputStream = new StreamReader(inputFile);

            if (!string.IsNullOrEmpty(inputFile))
            {
                var inputLines = new List<string>();
                var inputLinesByParameter = new List<List<string>>();

                string inputLine;
                while ((inputLine = inputStream.ReadLine()) != null)
                {
                    inputLines.Add(inputLine);
                    inputLinesByParameter.Add(SplitInput(inputLine, inputTokens));
                }

                inputStream.Close();
            }
        }

        public static IEnumerable<string> ParseLines(string inputFile)
        {
            var inputStream = new StreamReader(inputFile);

            if (!string.IsNullOrEmpty(inputFile))
            {
                string inputLine;
                while ((inputLine = inputStream.ReadLine()) != null)
                {
                    yield return inputLine;
                }

                inputStream.Close();
            }
        }

        //protected void PrintEstimatedCompletion(long total, long numberComplete, TimeSpan elapsedTime)
        //{
        //    var percentDone = (double)numberComplete / total;

        //    var completionTime = new TimeSpan();
        //    for (double timeSpanIndex = 0; timeSpanIndex < 1 / percentDone; ++timeSpanIndex)
        //    {
        //        completionTime += elapsedTime;
        //    }

        //    Console.WriteLine($"{numberComplete} ({percentDone * 100}%) finished in {elapsedTime}");
        //    Console.WriteLine($"  {completionTime} projected total run time.\n");
        //}
    }
}
