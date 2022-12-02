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
    }
}
